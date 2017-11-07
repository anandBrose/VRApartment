using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackScript : MonoBehaviour {

    public GameObject UIs;
    public GameObject homesList;
    public GameObject loading;
    private bool nowHighlighted = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && nowHighlighted)
        {
            UIs.SetActive(true);
            homesList.SetActive(false);
            this.nowHighlighted = false;
        }

    }

    public void Entered(string data)
    {
        this.nowHighlighted = true;
    }

    public void Exit()
    {
        this.nowHighlighted = false;
    }
}
