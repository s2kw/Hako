/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


PrefabRefObj.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( PrefabRefObj ) )]
public class PrefabRefObjInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as PrefabRefObj;
	}
}
# endif

// namespace jigaX{
public class PrefabRefObj : ScriptableObject {

	public GameObject prefab;

}

// } // namespace