/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp


ScriptableObjectCreator.cs

Date:
Description:

-------------------------------------------------*/



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UniRx; using UnityEngine.UI;
# if UNITY_EDITOR
using UnityEditor;

public class ScriptableObjCreator : Editor {
    public static void CreateAsset<Type>() where Type : ScriptableObject{
        Type item = (Type)ScriptableObject.CreateInstance<Type>();

        if( item == null ){
            Debug.LogError( "item could not created." + typeof( Type ).Name );
            return;
        }

        string path = AssetDatabase.GenerateUniqueAssetPath("Assets/new " + typeof(Type) + ".asset");

        Debug.Log("create at " + path);

        AssetDatabase.CreateAsset( item, path );
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = item;
    }
    
    // RandomSound
	[MenuItem("ScriptableObj/Create/PrefabRefObj")]
	static void CreateRandomSoundAsset() {
		ScriptableObjCreator.CreateAsset<PrefabRefObj>();
	}


}
# endif