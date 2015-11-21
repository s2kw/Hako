/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


BGScrollChild.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( BGScrollChild ) )]
public class BGScrollChildInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as BGScrollChild;
	}
}
# endif

// namespace jigaX{
public class BGScrollChild : MonoBehaviour {

	public delegate void EventHandler(BGScrollChild child);
	public EventHandler OnOutCamera;
	bool alreadyVisible = false;
	
	void Awake(){
		this.alreadyVisible = false;
	}
	void OnBecameInvisible(){
//		Debug.Log("OnBecameInvisible " + this.gameObject.name ,this );
		if( this.alreadyVisible && this.OnOutCamera != null ){
			this.OnOutCamera( this );
		}
	}
	void OnBecameVisible(){
//		Debug.Log("OnBecameVisible " + this.gameObject.name ,this );
		this.alreadyVisible = true;		
	}
	
}

// } // namespace