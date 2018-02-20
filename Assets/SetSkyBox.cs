using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkyBox : MonoBehaviour {

    private bool nowHighlighted = false;
    public Material material;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && nowHighlighted)
        {
            this.nowHighlighted = false;
            RenderSettings.skybox = material;
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
