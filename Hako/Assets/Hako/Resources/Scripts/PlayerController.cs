/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


PlayerController.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( PlayerController ) )]
public class PlayerControllerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as PlayerController;
	}
}
# endif

// namespace jigaX{
public class PlayerController : ObservableMonoBehaviour {

	Animator m_animator;
	public Animator animator{
		get{
			if(this.m_animator == null) this.m_animator = GetComponent<Animator>();
			return this.m_animator;
		}
		set{
			this.m_animator = value;
		}
	}

	CharacterController m_controller;
	public CharacterController controller{
		get{
			if(this.m_controller == null) this.m_controller = GetComponent<CharacterController>();
			return this.m_controller;
		}
		set{
			this.m_controller = value;
		}
	}
	Rigidbody m_rigidbody;
	public Rigidbody rigidbody{
		get{
			if(this.m_rigidbody == null) this.m_rigidbody = GetComponent<Rigidbody>();
			return this.m_rigidbody;
		}
		set{
			this.m_rigidbody = value;
		}
	}


	[SerializeField]float speed;
	[SerializeField]float jumpForce = 1f;
	float m_rightVector;
	float rightVector{
		get{
			return this.m_rightVector;
		}
		set{
			this.animator.SetFloat("moveSpeed", Mathf.Abs( value ) );
			this.m_rightVector = value;
		}
	}
	// Use this for initialization
	public override void Start () {

		var ArrowUpStream = UpdateAsObservable().Where( _ => Input.GetKeyUp( KeyCode.LeftArrow ) || Input.GetKeyUp( KeyCode.RightArrow ) );
		ArrowUpStream.Subscribe( _=> {
			this.rightVector = 0f;
		});

		var rightDownStream = UpdateAsObservable().Where(_=> Input.GetKey(KeyCode.RightArrow) );
		rightDownStream.Subscribe(_=>{
			this.RunToRight();
		});
		
		var leftDownStream = UpdateAsObservable().Where(_=> Input.GetKey(KeyCode.LeftArrow) );
		leftDownStream.Subscribe(_=>{
			this.RunToLeft();
		});
		
		// 地面判定
        this.controller
            .ObserveEveryValueChanged( x => x.isGrounded )
            .Where( x => this.controller.isGrounded == true )
            .Subscribe(x => this.isGround = x);	
		// jump
		var SpaceDownStream = UpdateAsObservable().Where(_=> Input.GetKeyDown(KeyCode.Space) );
		SpaceDownStream.Subscribe(_=>{
			this.Jump();
		});		

		// 最後に移動処理
		Observable.EveryUpdate()
					.Subscribe( _=>{
						this.Move();
					});
		
	}
	public override void OnCollisionEnter( Collision _col ){
		base.OnCollisionEnter( _col );
		Debug.Log(_col.gameObject.name,this);
		this.isGround = true;
	}
	float gravity = Physics.gravity.y;
	[SerializeField]Vector3 velocity;
	void Jump(){
		if (! this.isGround ) return;
			
		this.velocity.y = this.jumpForce;
		this.isGround = false;
	}
	public void Move(){
		var v = Vector3.right * this.rightVector;
		this.velocity.x = v.x;
		if( !this.isGround){
			this.velocity.y += gravity * Time.deltaTime;
		}
		this.controller.Move( this.velocity * Time.deltaTime );
	}
	
	[SerializeField]bool m_isGround;
	bool isGround{
		get{
			return this.m_isGround;
		}
		set{
			this.animator.SetBool("isGround",value);
			this.m_isGround = value;
		}
	}
	[SerializeField] ForceMode forceMode;
	[SerializeField] float dir;
	void RunToRight(){
		this.rightVector = this.speed;
		var v = Vector3.right;
		v.z -= dir;
		this.transform.rotation = Quaternion.LookRotation( v );
	}
	void RunToLeft(){
		this.rightVector = -this.speed;
		var v = -Vector3.right;
		v.z -= dir;
		this.transform.rotation = Quaternion.LookRotation( v );		
	}
	
}

// } // namespace