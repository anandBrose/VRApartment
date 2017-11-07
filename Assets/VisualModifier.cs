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


//    public void SetColor(string rgb) {
  //      Color color = new Color();
    //    color.r = float.Parse(s, CultureInfo.InvariantCulture);
      //  GetComponent<MeshRenderer>().material.color = color;
   // }

    public void SetTexture(Texture texture)
    {
        GetComponent<MeshRenderer>().material.mainTexture = texture;
    }
}
