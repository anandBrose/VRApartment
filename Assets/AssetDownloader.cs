using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class AssetDownloader : MonoBehaviour {

	public static HomeListView.Home home;
    void Start()
    {
        StartCoroutine(GetAssetBundle());
    }

    IEnumerator GetAssetBundle()
    {
		UnityWebRequest www = UnityWebRequest.GetAssetBundle(home.url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            Debug.Log("Success");
            bundle.LoadAllAssetsAsync();
            foreach (var name in bundle.GetAllAssetNames())
            {
                Debug.Log(name);

                AssetBundleRequest request = bundle.LoadAssetAsync (name, typeof(GameObject));
                
                yield return request;
                
               GameObject obj = request.asset as GameObject;
               GameObject.Instantiate(obj);
				bundle.Unload (false);
            }
            RestoreAll(LightmapsMode.CombinedDirectional, false, true);
			GameObject.FindObjectOfType<Customizer> ().initialize ();
        }

    }
    // Update is called once per frame
    void Update () {
		if (Input.GetButtonDown("Fire2"))
		{
			SceneManager.LoadScene("Menu");
		}

	}
    void RestoreAll(LightmapsMode mode, bool removeComponentsAfterwards = false, bool setStatic = false)
    {
        List<LightmapData> newLightmaps = new List<LightmapData>();

        foreach (LightmapParams p in FindObjectsOfType<LightmapParams>())
        {
            Renderer r = p.gameObject.GetComponent<Renderer>();
            if (!r)
                continue;

            r.lightmapIndex = p.lightmapIndex;
            r.lightmapScaleOffset = p.lightmapScaleOffset;

            // collect lightmaps from references: 
            while (newLightmaps.Count <= p.lightmapIndex)
                newLightmaps.Add(new LightmapData());
            newLightmaps[p.lightmapIndex].lightmapDir = p.lightmapNear;
            newLightmaps[p.lightmapIndex].lightmapColor = p.lightmapFar;

            if (setStatic)
                r.gameObject.isStatic = true;

            if (removeComponentsAfterwards)
                Destroy(p);
        }

        // activate: 
        LightmapSettings.lightmaps = newLightmaps.ToArray();
        LightmapSettings.lightmapsMode = mode;
    }
}
