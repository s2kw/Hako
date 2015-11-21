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

	public RandomSoundPlayer actionSound;
	public RandomSoundPlayer dieSound;
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
	public override void OnDestroy(){
		this.dieSound.Play();
		Singleton<GameController>.Instance.animator.SetTrigger("GameOver");

		base.OnDestroy();

		eventResources.Dispose();	
	}
	CompositeDisposable eventResources = new CompositeDisposable();
	Vector3 startPosition;
	// Use this for initialization
	public override void Start () {
		startPosition = this.transform.position;
		var ArrowUpStream = UpdateAsObservable().Where( _ => Input.GetKeyUp( KeyCode.LeftArrow ) || Input.GetKeyUp( KeyCode.RightArrow ) );
		ArrowUpStream.Subscribe( _=> {
			this.rightVector = 0f;
		}).AddTo(this.eventResources);

		var rightDownStream = UpdateAsObservable().Where(_=> Input.GetKey(KeyCode.RightArrow) );
		rightDownStream.Subscribe(_=>{
			this.RunToRight();
		}).AddTo(this.eventResources);
		
		var leftDownStream = UpdateAsObservable().Where(_=> Input.GetKey(KeyCode.LeftArrow) );
		leftDownStream.Subscribe(_=>{
			this.RunToLeft();
		}).AddTo(this.eventResources);
		
		// 地面判定
        this.controller
            .ObserveEveryValueChanged( x => x.isGrounded )
            .Where( x => this.controller.isGrounded == true )
            .Subscribe(x => this.isGround = x).AddTo(this.eventResources);
		
		this.ObserveEveryValueChanged( x => x.distance )
			.Where( _ => this.distance > this.previousDistance )
			.Subscribe( x => {
				this.previousDistance = this.distance;
				Singleton<MainCanvas>.Instance.mainInstance.UpdateDistance( this.distance );
				Singleton<GameController>.Instance.highScore = this.distance;
			}).AddTo(this.eventResources);
		
		UpdateAsObservable()
			.Subscribe(_=> {
				this.distance = Vector3.Distance( this.transform.position, this.startPosition );
				this.additionalPower /= 1.01f;
			} )
			.AddTo( this.eventResources );
		
		OnCollisionExitAsObservable().Subscribe(_=>{
			this.isGround = false;
		}).AddTo(this.eventResources);
		
		// jump
		var SpaceDownStream = UpdateAsObservable().Where(_=> Input.GetKeyDown(KeyCode.Space) );
		SpaceDownStream.Subscribe(_=>{
			this.Jump();
		}).AddTo(this.eventResources);	

		// 最後に移動処理
		Observable.EveryUpdate()
					.Subscribe( _=>{
						this.Move();
					}).AddTo(this.eventResources);
	}
	
	public float distance{ get;set; }
	public float previousDistance{ get;set; }
	[SerializeField] float forceObNugget;
	float gravity = Physics.gravity.y;
	public Vector3 velocity;
	public Vector3 additionalPower;
	void Jump(){
		if (! this.isGround ) return;
			
		this.velocity.y = this.jumpForce;
		this.isGround = false;
		this.actionSound.Play();
	}
	public void Move(){
		var v = Vector3.right * this.rightVector;
		this.velocity.x = v.x;
		if( !this.isGround){
			this.velocity.y += gravity * Time.deltaTime;
		}
		var p = this.velocity + this.additionalPower;
		if( this.controller != null )
			this.controller.Move( p * Time.deltaTime );
	}
	
	[SerializeField]bool m_isGround;
	public bool isGround{
		get{
			return this.m_isGround;
		}
		set{
			this.animator.SetBool("isGround",value);
			this.m_isGround = value;
			// 接地したのでエネルギーを消化
			if(value){
				this.additionalPower = Vector3.zero;
				this.velocity.y = 0f;
			}
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