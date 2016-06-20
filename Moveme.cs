using UnityEngine;
using System;
using System.Collections;

public class Moveme : MonoBehaviour {
	public GameObject controls;
	public float trainSpeed = 2f;
	Vector3 trainPos;
	Vector3 targetPos;
	Vector3 prevPos;
	RaycastHit Hit;

	void Start(){
		prevPos = this.transform.position;
		targetPos = this.transform.position;
	}

	void Update(){
		Menu trainCont = controls.GetComponent<Menu> ();
		prevPos = this.transform.position;
		Collider[] hitColliders = Physics.OverlapSphere (prevPos, 0.6f, ~5);
		int i = 0;
		while (i < hitColliders.Length) {
			if (hitColliders [i].transform.position != prevPos) {
				targetPos = new Vector3 (Mathf.Round(hitColliders [i].transform.position.x), Mathf.Round(hitColliders [i].transform.position.y), 0);
			}
			if (hitColliders [i].CompareTag ("endPoint")) {
				Debug.Log ("You have reached your destination");
				trainCont.winGame ();
			}
			//Debug.Log (hitColliders [i].tag);
			hitColliders = new Collider[i];
			i++;
			if (trainCont.runtrain == true) {
				moveTrain ();
			}
		}

	}

	void moveTrain(){
		this.transform.position = Vector3.MoveTowards (prevPos,targetPos,trainSpeed);

	}
}
