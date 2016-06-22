using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CodeBase : MonoBehaviour {
	public GameObject player;
	private GameObject thePrefab;
	public GameObject trackVert;
	public GameObject trackHoriz;
	public GameObject tunnelEntrance;
	public GameObject trackBridge;
	public GameObject trackTurn1;
	public GameObject trackTurn2;
	public GameObject trackTurn3;
	public GameObject trackTurn4;
	public int contact;
	public int blockSel;
	public float clickPause = 0.25f;
	private float time;
	Vector3 wordPos;
	Vector3 snappedPos;
	int partNo;
	bool nearPart;

	void Start () {
		contact = 0;
		blockSel = 0;
		time = clickPause;
		partNo = 1;
	
	}

	void Update () {
		time -= Time.deltaTime;
		//contact = 0;
		//Track Selector
		if (Input.GetKey (KeyCode.Alpha0)) {
			deleteMe();
			//Debug.Log ("Deletion Tool Selected");
			//blockSel = 0;
		}

		if (partNo == 1) {
			thePrefab = trackVert;
			Debug.Log ("Vectical Track Selected");
			blockSel = 1;
		}
		if (partNo == 2) {
			thePrefab = trackHoriz;
			Debug.Log ("Horizontal Track Selected");
			blockSel = 2;
		}
		if (partNo == 3) {
			thePrefab = tunnelEntrance;
			Debug.Log ("Tunnel Selected");
			blockSel = 3;
		}
		if (partNo == 4) {
			thePrefab = trackBridge;
			Debug.Log ("Bridge Selected");
			blockSel = 4;
		}

		if (partNo == 5) {
			thePrefab = trackTurn1;
			Debug.Log ("Turn 1 Selected");
			blockSel = 5;
		}
		if (partNo == 6) {
			thePrefab = trackTurn2;
			Debug.Log ("Turn 2 Selected");
			blockSel = 6;
		}
		if (partNo == 7) {
			thePrefab = trackTurn3;
			Debug.Log ("Turn 3 Selected");
			blockSel = 7;
		}
		if (partNo == 8) {
			thePrefab = trackTurn4;
			Debug.Log ("Turn 4 Selected");
			blockSel = 8;
		}

		if (partNo >= 9) {
			partNo = 1;
		}
		if (partNo <= 0) {
			partNo = 8;
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			prevPart ();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			nextPart ();
		}




		//Mouse Raycasting
		if (Input.GetMouseButtonDown (0) && (time < 0f)) {
			time = clickPause;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit Hit;
			//Track Detection
			if (Physics.Raycast (ray, out Hit, 10f)) {
				if (Hit.collider.CompareTag ("TrackParts") && blockSel != 3 && blockSel != 0) {
					contact = 1;
				}
				if (Hit.collider.CompareTag ("GroundLayer") && blockSel != 3 && blockSel != 4 && blockSel != 0) {
					contact = 2;
				}
				if (Hit.collider.CompareTag ("Terrain") && blockSel != 4) {
					contact = 3;
				}
				if (Hit.collider.CompareTag ("Veg")) {
					contact = 4;
				}
				if (Hit.collider.CompareTag ("Terrain") && blockSel == 4 && blockSel != 0) {
					contact = 2;
				}
				if (Hit.collider.CompareTag ("TrackSupport") && blockSel != 3 && blockSel != 4 && blockSel != 0) {
					contact = 2;
				}
				if ((Hit.collider.CompareTag ("TrackSupport") || Hit.collider.CompareTag ("TrackParts")) && blockSel == 0) {
					contact = 5;
				}
			}
			//Snapped Placement
			if (contact == 2) {
				wordPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				snappedPos = new Vector3 (Mathf.Round (wordPos.x), Mathf.Round (wordPos.y), 0);
				Instantiate (thePrefab, snappedPos, Quaternion.identity);
				//Debug.Log ("Track Placed");
			}
			else if (contact == 1) {
				Debug.Log ("There is already track here");
			}
			else if (contact == 3) {
				Debug.Log ("You must place support first");
			}
			else if (contact == 4) {
				Debug.Log ("You must clear the vegetation first");
			}
			//Track & Support Deletion
			else if (contact == 5) {
				//Destroy (Hit.collider.gameObject);
				deleteMe();
				Debug.Log ("Object Deleted");
			}
		}
		contact = 0;
	}

	void deleteMe(){
		GameObject[] tracks = GameObject.FindGameObjectsWithTag("TrackParts");
		for ( int i = 0; i < tracks.Length; i++) {
			Debug.Log (tracks [i].gameObject.name);
			Destroy (tracks [i].gameObject);
		}
		GameObject[] tracks2 = GameObject.FindGameObjectsWithTag("TrackSupport");
		for ( int i = 0; i < tracks2.Length; i++) {
			Debug.Log (tracks2 [i].gameObject.name);
			Destroy (tracks2 [i].gameObject);
		}
		GameObject[] tracks3 = GameObject.FindGameObjectsWithTag("TrackParts2");
		for ( int i = 0; i < tracks3.Length; i++) {
			Debug.Log (tracks3 [i].gameObject.name);
			Destroy (tracks3 [i].gameObject);
		}
	}

	public void prevPart(){
		partNo--;
		Debug.Log ("Previous Part");
	}

	public void nextPart(){
		partNo++;
		Debug.Log ("Next Part");
	}
}