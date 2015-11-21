/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


Destroyer.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( Destroyer ) )]
public class DestroyerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as Destroyer;
	}
}
# endif

// namespace jigaX{
public class Destroyer : MonoBehaviour {


	void OnTriggerEnter( Collider _col ){
		Destroy( _col.gameObject );
	}
}

// } // namespace