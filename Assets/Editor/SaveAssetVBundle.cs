using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SaveAssetVBundle : Editor {
    [MenuItem("Bundle/CreateSceneLoader")]
    static void AndroidBuild()
    {
        string[] levels = new string[] { "Assets/Scenes/Interior.unity" };

        BuildPipeline.BuildStreamedSceneAssetBundle(levels, "Assets/Bundles/InteriorSceneAndroid.unity3d", BuildTarget.Android);
    }
}
