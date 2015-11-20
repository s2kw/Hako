/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


ResultViewController.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( ResultViewController ) )]
public class ResultViewControllerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as ResultViewController;
	}
}
# endif

// namespace jigaX{
public class ResultViewController : MonoBehaviour {

	void Awake(){
	
	}

	// Use this for initialization
	void Start () {
		Singleton<MainCanvas>.Instance.resultInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

// } // namespace