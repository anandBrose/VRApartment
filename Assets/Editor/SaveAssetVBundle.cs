using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SaveAssetVBundle : Editor
{
    /* [MenuItem("Bundle/CreateInteriorSceneBundle")]
     static void AndroidBuild()
     {
         string[] levels = new string[] { "Assets/Scenes/Interior.unity" };

         BuildPipeline.BuildStreamedSceneAssetBundle(levels, "Assets/Bundles/InteriorSceneAndroid.unity3d", BuildTarget.Android);
     }*/

    [MenuItem("Bundle/BuildAssetBundles")]
    static void BuildAllAssetBundles()
    {
        var names = AssetDatabase.GetAllAssetBundleNames();
        foreach (var name in names)
            Debug.Log("AssetBundle: " + name);
        string path = "Assets/Bundles";
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
	private static string SelectedTag = "Floor";

	[MenuItem("Helpers/Select By Tag")]
	public static void SelectObjectsWithTag()
	{
		
		GameObject[] objects = GameObject.FindGameObjectsWithTag(Selection.gameObjects[0].tag);
		Selection.objects = objects;
	}
    /// <summary>This function is called from an editor action and creates or updates this component on all objects with renderers and static lightmap in the current scene. </summary>
    [MenuItem("Bundle/BindPrefabLightParams")]
    public static void StoreAll()
    {
        foreach (Renderer r in FindObjectsOfType<Renderer>())
            if (r.lightmapIndex != -1)
            {
                LightmapParams lmp = r.gameObject.GetComponent<LightmapParams>();
                if (!lmp)
                    lmp = r.gameObject.AddComponent<LightmapParams>();
                lmp.lightmapIndex = r.lightmapIndex;
                lmp.lightmapScaleOffset = r.lightmapScaleOffset;
                lmp.lightmapNear = LightmapSettings.lightmaps[lmp.lightmapIndex].lightmapDir;
                lmp.lightmapFar = LightmapSettings.lightmaps[lmp.lightmapIndex].lightmapColor;
            }

    }
    
    /// <summary>This function is called from an editor action to remove all <see cref="LightmapParams"/> components in the scene.</summary>
    [MenuItem("Bundle/RemovePrefabLightParams")]
    public static void RemoveAll()
    {
        foreach (LightmapParams p in FindObjectsOfType<LightmapParams>())
            DestroyImmediate(p);
    }
}
