/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


AbstractGameControllerState.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( AbstractGameControllerState ) )]
public class AbstractGameControllerStateInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as AbstractGameControllerState;
	}
}
# endif

// namespace jigaX{
public class AbstractGameControllerState : StateMachineBehaviour {
	[SerializeField]protected Util.GameStates state;
	[SerializeField]protected PrefabRefObj prefabRefObj;
	protected Transform m_canvas;
	protected Transform canvas{
		get{
			if(this.m_canvas == null) this.m_canvas = Singleton<MainCanvas>.Instance.transform;
			return this.m_canvas;
		}
		set{
			this.m_canvas = value;
		}
	}
	[SerializeField]protected GameObject currentRootUIPrefab;
	[SerializeField]GameObject m_currentRootUIInstance;
	protected GameObject currentRootUIInstance{
		get{
			if( this.m_currentRootUIInstance == null ){
				this.m_currentRootUIInstance = Util.InstantiateWithParentForUI(this.currentRootUIPrefab );
			}
			return this.m_currentRootUIInstance;
		}
		set{
			this.m_currentRootUIInstance = value;
		}
	}
	
}

// } // namespace