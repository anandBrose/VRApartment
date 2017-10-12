using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Camera.main.transform.forward*Input.GetAxis("Vertical")*Time.deltaTime*2f;
        transform.position += Camera.main.transform.right*Input.GetAxis("Horizontal")*Time.deltaTime*2f;
	}
}
