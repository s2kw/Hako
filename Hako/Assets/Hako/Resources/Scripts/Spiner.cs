/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


Spiner.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( Spiner ) )]
public class SpinerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		var script = target as Spiner;
	}
}
# endif

// namespace jigaX{
public class Spiner : MonoBehaviour {

	[RangeAttribute(0.001f,3f)][SerializeField] float spiningSpeed = 1f;
	[SerializeField] Transform spiningTarget;
	[SerializeField] bool isLocal = false;
	// Update is called once per frame
	void Update () {
		if( this.spiningTarget == null ){
			this.spiningTarget = this.transform;
		}
		if( this.isLocal ){
			var v3 = Vector3.Lerp( this.spiningTarget.forward, this.spiningTarget.right, this.spiningSpeed * 0.1f );
			this.spiningTarget.rotation =  Quaternion.LookRotation ( v3, this.spiningTarget.up );
		}else{
			var v3 = Vector3.Lerp( this.spiningTarget.forward, this.spiningTarget.right, this.spiningSpeed * 0.1f );
			this.spiningTarget.rotation =  Quaternion.LookRotation( v3, Vector3.up );		
		}
	}
	
}

// } // namespace