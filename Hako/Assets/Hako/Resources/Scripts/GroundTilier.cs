/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


GroundTilier.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( GroundTilier ) )]
public class GroundTilierInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as GroundTilier;
	}
}
# endif

// namespace jigaX{
public class GroundTilier : MonoBehaviour {
	[SerializeField] GameObject groundPartPrefab;
	[SerializeField] int tilingCount = 20;

	// Use this for initialization
	void Start () {
		Tiling();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Tiling(){
		if( this.groundPartPrefab == null ){
			Debug.LogError("Tile is null",this);
			return;
		}
		for(int i = 0; i < this.tilingCount; i++ ){
			var g = Instantiate( this.groundPartPrefab );
			g.transform.SetParent(this.transform);
			g.transform.localPosition = new Vector3( i * - 1f, 0f, 0f );
		}
	}
}

// } // namespace