using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Moveme : MonoBehaviour {
	public GameObject controls;
	public float trainSpeed = 2f;
	Vector3 trainPos;
	Vector3 targetPos;
	Vector3 prevPos;
	public GameObject[] tracks;
	//int search = 0;
	bool runtrain = false;

	GameObject closest;
	float dist;

	void Start(){
		prevPos = this.transform.position;
		targetPos = this.transform.position;
		dist = Mathf.Infinity;
		closest = null;
	}

	void Update(){
		Menu trainCont = controls.GetComponent<Menu> ();
		prevPos = this.transform.position;
		FindClosestObj ();
		Debug.Log (closest.transform.position);
		targetPos = closest.transform.position;

		if (Vector3.Distance (prevPos, targetPos) == 0) {
			closest.gameObject.tag = "TrackParts2";
			//searchArray();
			Array.Clear(tracks, 0, tracks.Length);
			closest = tracks[0];
		}
		if (runtrain == true) {
			moveTrain ();
		}
		Debug.Log("end update");
		Array.Clear (tracks, 0, tracks.Length);
		Collider[] hitColliders = Physics.OverlapSphere (prevPos, 0.6f, ~5);
		int i = 0;
		while (i < hitColliders.Length) {
			if (hitColliders [i].CompareTag ("endPoint")) {
				Debug.Log ("You have reached your destination");
				trainCont.winGame ();
			}
			hitColliders = new Collider[i];
			i++;
		}
		Start ();
	}
	
	void moveTrain(){
		this.transform.position = Vector3.MoveTowards (prevPos,targetPos,trainSpeed);
	}

	GameObject FindClosestObj(){
		tracks = GameObject.FindGameObjectsWithTag ("TrackParts");
		foreach (GameObject track in tracks) {
			Vector3 diff = track.transform.position - prevPos;
			float curDist = diff.sqrMagnitude;
			if (curDist < dist) {
				closest = track;
				dist = curDist;
			}
		}
		return closest;
	}
	public void runTrain(){
		if (!runtrain) {
			runtrain = true;
			Debug.Log ("Run Train");
		} else if (runtrain) {
			runtrain = false;
			Debug.Log ("Stop Train");
		}
	}
}