/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


Mover.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( Mover ) )]
public class MoverInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as Mover;
	}
}
# endif

// namespace jigaX{
public class Mover : ObservableMonoBehaviour {
	CompositeDisposable eventResources = new CompositeDisposable();
	[SerializeField] Vector3 moveVector;
	// Use this for initialization
	public override void Start () {
		base.Start();
		
		Observable.EveryUpdate().Subscribe(_=>{
			this.transform.localPosition += this.moveVector;
		}).AddTo(this.eventResources);
		
	}
	
	public override void OnDestroy(){
		base.OnDestroy();
		eventResources.Dispose();
	}
	
}

// } // namespace