/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


ButtonTrigger.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( ButtonTrigger ) )]
public class ButtonTriggerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as ButtonTrigger;
	}
}
# endif

// namespace jigaX{
public class ButtonTrigger : MonoBehaviour {
	[SerializeField]string triggerName;
	public void OnButtonDown(){
		Singleton<GameController>.Instance.animator.SetTrigger(this.triggerName);
	}

}

// } // namespace