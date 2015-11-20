/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


Util.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx; using UnityEngine.UI;

public class Util {
	public enum GameStates{
		Title,
		Main,
		Result,
	}

	public static GameObject InstantiateWithParent( GameObject _prefab, Transform _parent ){
		var g = GameObject.Instantiate( _prefab ) as GameObject;
		g.transform.SetParent( _parent );
		g.transform.localPosition = Vector3.zero;
		return g;
	}
	public static GameObject InstantiateWithParentForUI( GameObject _prefab ){
		var g = GameObject.Instantiate( _prefab ) as GameObject;
		g.transform.SetParent( Singleton<MainCanvas>.Instance.transform );
		g.transform.localPosition = Vector3.zero;
		var r = g.GetComponent<RectTransform>();
		r.sizeDelta = Vector2.zero; 
		
		return g;
	}

}

// } // namespace