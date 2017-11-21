using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeListView : MonoBehaviour {
	public class Home{
		public string name = "";
		public string url = "";
		public int id;

		public Home(int id, string name, string url){
			this.id = id;
			this.name = name;
			this.url = url;
		}
	}
	public UnityEngine.UI.Text[] items;
	public int currentIndex;
	public GameObject loader;
	public GameObject content;
	public List <Home> list;
	public string url = "https://s3.ap-south-1.amazonaws.com/vrhomes/master.csv";
	IEnumerator Start()
	{
		this.items [0].text = this.items [1].text = this.items [2].text = "";
		this.loader.SetActive (true);
		this.content.SetActive (false);
		WWW www = new WWW(url);
		yield return www;
		string[] homesList = www.text.Split ('\n');
		int i = 0;
		list = new List<Home> ();
		foreach (string data in homesList) {
			i++;
			list.Add (new Home(i, data.Split(',')[0], data.Split(',')[1]));
		}
		this.currentIndex = 0;
		this.loader.SetActive (false);
		this.content.SetActive (true);
		this.populateUI ();

	}
	void populateUI(){
		this.items [0].text = this.items [1].text = this.items [2].text = "";
		for (int i = 0; i < this.items.Length && i < this.list.Count-this.currentIndex; i++) {
			this.items [i].text = this.list [i+this.currentIndex].id + "." + this.list [i+this.currentIndex].name;
		}
	}
	public void reset(){
		list = new List<Home> ();
		this.populateUI ();
		StartCoroutine (Start());
	}	
	// Update is called once per frame
	void Update () {
		
	}

	public void next(){
		if(list.Count>=this.currentIndex + 3)
			this.currentIndex = this.currentIndex + 3;
		this.populateUI ();
	}
	public void prev(){
		if(this.currentIndex >= 3)
			this.currentIndex = this.currentIndex - 3;
		this.populateUI ();

	}
	public void OnItemClick(int index){
		AssetDownloader.home = this.list [index + this. currentIndex];
		SceneManager.LoadScene("Sweethome");
	}
}
