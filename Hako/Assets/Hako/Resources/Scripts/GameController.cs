/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


GameController.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( GameController ) )]
public class GameControllerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as GameController;
	}
}
# endif

// namespace jigaX{
public class GameController : Singleton<GameController> {
	jigaX.CameraDolly m_cameraDolly;
	jigaX.CameraDolly cameraDolly{
		get{
			if( this.m_cameraDolly == null ) this.m_cameraDolly = Camera.main.GetComponent<jigaX.CameraDolly>();
			return this.m_cameraDolly;
		}
		set{
			this.m_cameraDolly = value;
		}
	}
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
	public GameObject playerPrefab;
	public GameObject startingGroundPrefab;
	
	float m_highScore;
	public float highScore{
		get{
			return this.m_highScore;
		}
		set{
			if (this.m_highScore < value ){
				this.m_highScore = value;
			}
		}
	}
	[SerializeField]Vector3 playerInstancePosition;
	public void ChangeStateAs( Util.GameStates _state ){
		StartCoroutine( this.DelayWithChangeState(_state) );
	}
	IEnumerator DelayWithChangeState( Util.GameStates _state ){
		yield return new WaitForSeconds(0.1f);
		switch(_state){
			case Util.GameStates.Title:
				this.cameraDolly.GoToStartPosition();
				CubePopper.Instance.gameObject.SetActive(false);
			break;
			case Util.GameStates.Main:
				this.m_highScore = 0f;
				Util.InstantiateWithParent( this.startingGroundPrefab, null );
				var g = Util.InstantiateWithParent( this.playerPrefab, null );
				g.transform.position = this.playerInstancePosition;
				this.cameraDolly.SetNewPlayer( g.transform );
				CubePopper.Instance.gameObject.SetActive(true);
				CubePopper.Instance.ResetPosition();
				CubePopper.Instance.gameObject.GetComponent<Mover>().ResetSpeed();
			break;
			case Util.GameStates.Result:
				CubePopper.Instance.gameObject.SetActive(false);
				Singleton<MainCanvas>.Instance.resultInstance.SetNewScore( this.highScore );
			break;
		}		
	}
	
	

}

// } // namespace