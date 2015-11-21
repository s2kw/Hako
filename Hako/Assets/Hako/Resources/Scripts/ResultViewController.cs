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

	// Use this for initialization
	void Start () {
		Singleton<MainCanvas>.Instance.resultInstance = this;
	}
	[SerializeField]RandomSoundPlayer gameOverSound;
	void OnEnable(){
		this.gameOverSound.Play();
	}
	
	[SerializeField] UnityEngine.UI.Text score;
	public void SetNewScore( float _score ){
		this.score.text = "あなたは\n" + Mathf.Floor(_score).ToString() + " m \nナゲットくんを追いかけました！";
	}
}

// } // namespace