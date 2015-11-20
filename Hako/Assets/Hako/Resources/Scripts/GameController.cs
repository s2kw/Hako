/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


GameController.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( GameController ) )]
public class GameControllerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as GameController;
	}
}
# endif

// namespace jigaX{
public class GameController : Singleton<GameController> {
	
	Animator m_animator;
	public Animator animator{
		get{
			if(this.m_animator == null) this.m_animator = GetComponent<Animator>();
			return this.m_animator;
		}
		set{
			this.m_animator = value;
		}
	}

}

// } // namespace