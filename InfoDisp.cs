using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoDisp : MonoBehaviour {
	int pageNo;

	// Use this for initialization
	void Start () {
		pageNo = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Text text = this.GetComponent<Text> ();
		if (pageNo <= 0) {
			pageNo = 1;
		}
		if (pageNo == 1) {
			text.text = "How to play:\n\n\n-Use 1-4 to select a track part to place\n\n-Left Click to place";
		}
		if (pageNo == 2) {
			text.text = "Background:\n\nIn 1863, the first public NZ railway opened in\nCanterbury.While it was a broader track than what\n" +
				"is used now, it set the stage for what was\nto come. Within 10 years, Auckland, Southland,\nand Otago all had provincial railways.\n" +
				"\nBy 1880, following the abolition of the provinces, the first main line had opened, linking Christchurch and Dunedin.\n" +
				"This track had to pass through hills, valleys,\nand native forest, ultimately overcoming natural boundaries.";
		}
		if (pageNo == 3) {
			text.text = "The first railways in the country used smaller\nlocomotives, based on contemporary English\ndesigns - in a few cases, they were even" +
				"\nimported after being made in England.\n\nAs time progressed, these locomotives were\nreplaced, mainly due to the smaller tracks" +
				"\nbeing installed across the country. However, some\nof the earliest lines in NZ still exist, having\nbecome part of our main rail network, where they\n" +
				"are still in use today.";
		}
		if (pageNo >= 4) {
			pageNo = 3;
		}
	}

	public void prevPage(){
		pageNo--;
		Debug.Log ("Previous Page");
	}

	public void nextPage(){
		pageNo++;
		Debug.Log ("Next Page");
	}
}
