﻿/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


NuggetBahaviour.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( NuggetBehaviour ) )]
public class NuggetBehaviourInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as NuggetBehaviour;
	}
}
# endif

// namespace jigaX{
public class NuggetBehaviour : ObservableMonoBehaviour {
	CompositeDisposable eventResources = new CompositeDisposable();
	
	public override void Start(){
		// OnCollisionEnterAsObservable().Subscribe(x=>{
		// 	Debug.Log("OnCollisionStayAsObservable");
		// 	Debug.Log( x.gameObject.name );
		// }).AddTo(this.eventResources);

		// OnCollisionStayAsObservable().Subscribe(x=>{
		// 	Debug.Log("OnCollisionStayAsObservable");
		// 	Debug.Log( x.gameObject.name );
		// }).AddTo(this.eventResources);
		
		OnTriggerEnterAsObservable().Subscribe(x=>{
			Debug.Log( "OnTriggerEnterAsObservable :" + x.gameObject.name );
			
			if( x.gameObject.tag != "Player" ) return;
			var p = x.gameObject.GetComponent<PlayerController>();
			if( p.isGround == false ) return;
			p.additionalPower = ( Vector3.up ) * 20f;
			p.additionalPower += Vector3.left * 10f;
			p.isGround = false;
			p.dieSound.Play();
			
			var m = this.transform.parent.gameObject.GetComponent<Mover>();
			m.max += m.max * 0.04f;
		}).AddTo(this.eventResources);
		
		
		// OnTriggerStayAsObservable().Subscribe(x=>{
		// 	Debug.Log("OnTriggerStayAsObservable");
		// 	Debug.Log( x.gameObject.name );
		// }).AddTo(this.eventResources);
	} 
	// public override void OnCollisionEnter( Collision _col ){
	// 	base.OnCollisionEnter( _col );
	// 	Debug.Log( _col.gameObject.name );
	// }
}

// } // namespace