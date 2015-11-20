/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


HiddenWallBehaviour.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( HiddenWallBehaviour ) )]
public class HiddenWallBehaviourInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as HiddenWallBehaviour;
	}
}
# endif

// namespace jigaX{
public class HiddenWallBehaviour : MonoBehaviour {
	
	[SerializeField] GameObject uiPrefab;
	GameObject instance;
	
	void ActivateUIInfo( bool _value ){
		if( this.instance == null ) this.instance = Util.InstantiateWithParentForUI( this.uiPrefab );
		this.instance.SetActive( _value );
	}
	
}

// } // namespace