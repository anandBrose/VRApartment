using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour {

    private bool nowHighlighted = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && nowHighlighted)
        {
            this.nowHighlighted = false;
            SceneManager.LoadScene("Menu");
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
