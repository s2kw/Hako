/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


SelectBrother.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( SelectBrother ) )]
public class SelectBrotherInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as SelectBrother;
	}
}
# endif

// namespace jigaX{
public class SelectBrother : MonoBehaviour {

	[SerializeField] Color defaultColor;
	[SerializeField] Color selectedColor;
	[SerializeField] GameObject targetPrefab;

	public UnityEngine.UI.Image img;
	void Start(){
		this.img = GetComponent<UnityEngine.UI.Image>();
	}
	void OnEnable(){
		this.OnUnselected();
	}
	public void OnButtonDown(){
		Singleton<GameController>.Instance.playerPrefab = this.targetPrefab;
		img.color = this.selectedColor;
		var p =this.targetPrefab.GetComponent<PlayerController>();
		p.actionSound.Play();
	}
	public void OnUnselected(){
		this.img.color = this.defaultColor;
	}

}

// } // namespace