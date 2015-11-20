/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


GameState.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( GameState ) )]
public class GameStateInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as GameState;
	}
}
# endif

// namespace jigaX{
public class GameState : AbstractGameControllerState {
	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
		if( this.currentRootUIInstance == null )
			Debug.Log("this.currentRootUIInstance is null");
		this.currentRootUIInstance.SetActive(true);
	}
	//public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){ Debug.Log( this.GetType().Name + ".OnStateUpdate ", this ); }
	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
		if( this.currentRootUIInstance == null ) return;
		this.currentRootUIInstance.SetActive( false );
	}
}

// } // namespace