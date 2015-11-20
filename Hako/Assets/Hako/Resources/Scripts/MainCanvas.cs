/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


MainCanvas.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( MainCanvas ) )]
public class MainCanvasInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as MainCanvas;
	}
}
# endif

// namespace jigaX{
public class MainCanvas : Singleton<MainCanvas> {
	public GameObject titleInstance;
	public MainUIViewController mainInstance;
	public GameObject resultInstance;
	
}

// } // namespace