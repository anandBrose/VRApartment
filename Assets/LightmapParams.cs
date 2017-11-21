using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Use the provided editor action to put this component on all objects that use static light maps, in order to have their lightmap parameters exported to an asset bundle and later restored properly. 
/// The corresponding lightmaps will automatically be referenced and included in the bundle. At loading time you need to have this script in your hosting project and call the static method RestoreAll. 
/// </summary>
public class LightmapParams : MonoBehaviour
{
    public Texture2D lightmapNear, lightmapFar;
    public int lightmapIndex;
    public Vector4 lightmapScaleOffset;
}