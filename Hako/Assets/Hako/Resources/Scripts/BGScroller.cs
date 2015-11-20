/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


BGScroller.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( BGScroller ) )]
public class BGScrollerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as BGScroller;
	}
}
# endif

// namespace jigaX{
public class BGScroller : MonoBehaviour {

	public List<BGScrollChild> children;

	void Awake(){
	
	}

	// Use this for initialization
	void Start () {
		var i = 0;
		foreach( var c in this.children ){
			c.transform.localPosition = new Vector3( i * this.offsetX, 0f, 0f );
			c.OnOutCamera += this.OnOutCameraEvent;
			i ++;
		}
	}
	[SerializeField] float offsetX;
	void OnOutCameraEvent( BGScrollChild _child ){
		this.children.Remove( _child );
		this.children.Add( _child );
		var top = this.children[0].transform.localPosition;
		
		_child.transform.localPosition = new Vector3( top.x + offsetX, top.y,top.z );
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// [SerializeField]float margin = 0.1f; //マージン(画面外に出てどれくらい離れたら消えるか)を指定
	// [SerializeField]float negativeMargin;
	// [SerializeField]float positiveMargin;
    // bool isOutOfScreen()
    // {
    //     Vector3 positionInScreen = Camera.main.WorldToViewportPoint(transform.position);
    //     positionInScreen.z = transform.position.z;
 
    //     if (positionInScreen.x <= negativeMargin ||
    //         positionInScreen.x >= positiveMargin ||
    //         positionInScreen.y <= negativeMargin ||
    //         positionInScreen.y >= positiveMargin)
    //     {
    //         return true;
    //     } else {
    //         return false;
    //     }
    // }

}

// } // namespace