using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualModifier : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetColor()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public void SetTexture(Texture texture)
    {
        GetComponent<MeshRenderer>().material.mainTexture = texture;
    }
}
