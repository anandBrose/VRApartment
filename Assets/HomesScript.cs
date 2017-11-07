using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomesScript : MonoBehaviour {
    public GameObject UIs;
    public GameObject homesList;
    public GameObject loading;
    private bool nowHighlighted = false;
    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")&&nowHighlighted)
        {
            UIs.SetActive(false);
            homesList.SetActive(true);
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