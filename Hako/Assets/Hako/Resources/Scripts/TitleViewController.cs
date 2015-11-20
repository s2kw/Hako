/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


TitleViewController.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( TitleViewController ) )]
public class TitleViewControllerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as TitleViewController;
	}
}
# endif

// namespace jigaX{
public class TitleViewController : MonoBehaviour {

	public GameObject UIPlayerCharacteSelectorController;
	public RandomSoundPlayer actionSound;
	void OnEnable(){
		this.UIPlayerCharacteSelectorController.SetActive(true);
		this.actionSound.Play();
	}
	// Use this for initialization
	void Start () {
		Singleton<MainCanvas>.Instance.titleInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

// } // namespace