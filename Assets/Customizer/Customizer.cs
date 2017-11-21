using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customizer : MonoBehaviour {

    public Material[] Wall;
    public Material[] Floor;
    public Material[] Sofa;
    public Material[] Bed;
    public Material[] Wood;
    public Material[] TV;
    public Material[] Table;
    public Material[] Chair;
    public Material[] Door;
    public Material[] Metal;

    public void initialize()
    {
		GameObject downloadMessage = GameObject.Find ("DownloadingMessage");
		downloadMessage.SetActive (false);
		GameObject.FindObjectOfType<CharacterControl> ().enabled = true;
		foreach (GameObject renderer in GameObject.FindGameObjectsWithTag ("Wall")) {
			if(AssetDownloader.home.id-1 <= Wall.Length-1)
				renderer.GetComponent<Renderer> ().material = Wall[AssetDownloader.home.id-1];
			else
				renderer.GetComponent<Renderer> ().material = Wall[0];
		}
		foreach (GameObject renderer in GameObject.FindGameObjectsWithTag ("Floor")) {
			renderer.GetComponent<Renderer> ().material = Floor[0];
		}
    }

}
