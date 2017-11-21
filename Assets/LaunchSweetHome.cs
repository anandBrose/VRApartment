using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchSweetHome : MonoBehaviour {

	private bool nowHighlighted = false;
	public GameObject listView;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && nowHighlighted)
        {
            this.nowHighlighted = false;
			listView.SetActive (true);
			listView.GetComponent<HomeListView> ().reset();
			gameObject.transform.parent.gameObject.SetActive (false);
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
