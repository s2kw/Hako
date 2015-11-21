/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


MainUIViewController.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( MainUIViewController ) )]
public class MainUIViewControllerInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as MainUIViewController;
	}
}
# endif

// namespace jigaX{
public class MainUIViewController : ObservableMonoBehaviour {

	[SerializeField] UnityEngine.UI.Text distanceMeter;
	[SerializeField] UnityEngine.UI.Text boxCounter;

	[SerializeField] Renderer sampleCube;
	public Material currentMaterial;
	[SerializeField] List<Material> materials;
	[SerializeField] float intervalSec  = 5f ; 
	public void UpdateDistance( float _val ){
		this.distanceMeter.text = Mathf.Floor(_val).ToString() + " m";
	}
	
	public void UpdateBoxCount( int _val ){
		this.boxCounter.text = _val.ToString() + "ハコ";
	}

	CompositeDisposable eventResources = new CompositeDisposable();
	// Use this for initialization
	public override void Start () {
		base.Start();
		Singleton<MainCanvas>.Instance.mainInstance = this;
		
		Observable.Interval( System.TimeSpan.FromSeconds(this.intervalSec ) )
			.TakeUntilDisable(this)
			.Subscribe(_=>{
				this.MaterialChange();
			}).AddTo( this.eventResources );
	}
	public override void OnDestroy(){
		base.OnDestroy();
		this.eventResources.Dispose();
	}
	
	public void MaterialChange(){
		var r = UnityEngine.Random.Range(0, this.materials.Count );
		var targetMaterial = this.materials[r];
		this.sampleCube.material = targetMaterial;
	}
	
}

// } // namespace