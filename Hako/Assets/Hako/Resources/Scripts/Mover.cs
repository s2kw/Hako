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
	Vector3 startVector;
	[SerializeField] bool isIncrease = false;
	[SerializeField] float max = 0.1f;
	// Use this for initialization
	public override void Start () {
		base.Start();
		this.startVector = this.moveVector;
		Observable.EveryUpdate().Subscribe(_=>{
			this.Move();
			this.Increase();
		}).AddTo(this.eventResources);
		
	}
	public void ResetSpeed(){
		this.moveVector = this.startVector;
	}
	void Move(){
		this.transform.localPosition += this.moveVector;
	}
	void Increase(){
		if( this.isIncrease && ( Mathf.Min( this.max, this.moveVector.magnitude ) < this.max ) )
			this.moveVector *= 1.001f;
		
	}
	public override void OnDestroy(){
		base.OnDestroy();
		eventResources.Dispose();
	}
	
}

// } // namespace