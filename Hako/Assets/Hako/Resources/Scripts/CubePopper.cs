/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


CubePopper.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;
[CustomEditor( typeof( CubePopper ) )]
public class CubePopperInspector : Editor{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		return;
		var script = target as CubePopper;
	}
}
# endif

// namespace jigaX{
public class CubePopper : ObservableMonoBehaviour {
	[SerializeField] float randomRangeHighest = 1f; 
	[SerializeField] float randomRangeLowest = -1f; 
	public List<GameObject> cubePrefabs;
	CompositeDisposable eventResources = new CompositeDisposable();
	public static CubePopper Instance;
	[SerializeField]float intervalSec = 1f;
	Vector3 startPosition;
	List<GameObject> cubes = new List<GameObject>();
	public Transform attackTarget; 
	// Use this for initialization
	public override void Awake(){
		base.Awake();
		Instance = this;
	}
	public override void Start () {
		base.Start();
		this.startPosition = this.transform.position;
	}
	public void ResetPosition(){
		while( this.cubes.Count > 0 ){
			var g = this.cubes[ this.cubes.Count -1 ];
			this.cubes.Remove(g);
			Destroy(g);
		}
		this.transform.position = this.startPosition;
	}
	public override void OnEnable(){
		base.OnEnable();
		Observable.Interval( System.TimeSpan.FromSeconds( this.intervalSec) )
			.TakeUntilDisable( this )
			.Subscribe(_=>{
				var r = UnityEngine.Random.Range(0,this.cubePrefabs.Count );
				var g = Util.InstantiateWithParent( this.cubePrefabs[r], null );
				var v = this.transform.position;
				v.y = UnityEngine.Random.Range(this.randomRangeLowest, this.randomRangeHighest );
				g.transform.position = v;
				this.cubes.Add(g);
			})
			.AddTo( this.eventResources );		
	}
	public override void OnDestroy(){
		base.OnDestroy();
		this.eventResources.Dispose();
	}
	
}

// } // namespace