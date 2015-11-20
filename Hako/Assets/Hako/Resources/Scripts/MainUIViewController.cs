/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


MainUIViewController.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( MainUIViewController ) )]
public class MainUIViewControllerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as MainUIViewController;
	}
}
# endif

// namespace jigaX{
public class MainUIViewController : MonoBehaviour {

	[SerializeField] UnityEngine.UI.Text distanceMeter;
	[SerializeField] UnityEngine.UI.Text boxCounter;

	public void UpdateDistance( float _val ){
		this.distanceMeter.text = Mathf.Floor(_val).ToString() + " m";
	}
	
	public void UpdateBoxCount( int _val ){
		this.boxCounter.text = _val.ToString() + "ハコ";
	}

	void Awake(){
	
	}

	// Use this for initialization
	void Start () {
		Singleton<MainCanvas>.Instance.mainInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

// } // namespace