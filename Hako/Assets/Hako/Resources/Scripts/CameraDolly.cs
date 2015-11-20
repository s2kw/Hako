/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


CameraDorry.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx;

namespace jigaX{
public class CameraDolly : ObservableMonoBehaviour {

	Transform followingTarget;
	Vector3 offsetOnStart;
	Vector3 startPosition;
	// Use this for initialization
	public override void Start () {
		base.Start();

		this.startPosition = this.transform.position;
		
		Observable.EveryUpdate().Subscribe( _=>{this.Apply();});
	}
	public void GoToStartPosition(){
		this.transform.position = this.startPosition;
	}
	public void SetNewPlayer( Transform _target ){
		this.followingTarget = _target;
		this.offsetOnStart = this.followingTarget.position - this.transform.position;
	}
	// Update is called once per frame
	[SerializeField]float defaultHeight = 0f;
	// Inspectorのボタンで呼ばせる関数
	# region Trigger from Inspectors
	public void Apply(){
		if( this.followingTarget == null ) return;
		var p = followingTarget.position;
		p.y = 0f;
		this.transform.position = p - this.offsetOnStart;
	}
	
	# endregion //Trigger from Inspectors
	
	Camera m_mainCam;
	Camera mainCam{
		get{
			this.m_mainCam = this.m_mainCam ?? Camera.main;
			return this.m_mainCam;
		}
		set{
			this.m_mainCam = value;
		}
	}
	public Vector2 cameraDir{
		get{
			var p = this.transform.position;
			var dollyPos = new Vector2( p.x, p.z );
			var mcamP = this.mainCam.transform.position;
			var maincamPos = new Vector2( mcamP.x, mcamP.z );
			var a = ( dollyPos - maincamPos ).normalized;
			return a;
		}
	}
}
}