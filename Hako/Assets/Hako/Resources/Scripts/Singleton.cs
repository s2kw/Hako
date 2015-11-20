/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


Singleton.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;


// namespace jigaX{
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	protected static readonly string[] findTags  =
	{
		"MainCanvas",
		"GameController",
	};

	protected static T instance;
	public static T Instance {
		get {
			
			return instance;
		}
	}
	
	protected virtual void Awake()
	{
		CheckInstance();
		this.OnAwake();
	}
	
	protected bool CheckInstance()
	{
		if( instance == null)
		{
			instance = (T)this;
			return true;
		}else if( Instance == this )
		{
			return true;
		}
		
		Destroy(this);
		return false;
	}
	protected virtual void OnAwake(){
		
	}
}

// } // namespace