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
	public int contact;
	public int blockSel;
	public float clickPause = 0.25f;
	private float time;

	void Start () {
		contact = 0;
		blockSel = 0;
		time = clickPause;
	
	}

	void Update () {
		time -= Time.deltaTime;
		//contact = 0;
		//Track Selector
		if (Input.GetKey (KeyCode.Alpha1)) {
			thePrefab = trackVert;
			Debug.Log ("Vectical Track Selected");
			blockSel = 1;
		} else if (Input.GetKey (KeyCode.Alpha2)) {
			thePrefab = trackHoriz;
			Debug.Log ("Horizontal Track Selected");
			blockSel = 2;
		} else if (Input.GetKey (KeyCode.Alpha3)) {
			thePrefab = tunnelEntrance;
			Debug.Log ("Tunnel Selected");
			blockSel = 3;
		} else if (Input.GetKey (KeyCode.Alpha4)) {
			thePrefab = trackBridge;
			Debug.Log ("Bridge Selected");
			blockSel = 4;
		} else if (Input.GetKey (KeyCode.Alpha0)) {
			thePrefab = null;
			Debug.Log ("Deletion Tool Selected");
			blockSel = 0;
		}
		//Mouse Raycasting
		if (Input.GetMouseButtonDown (0) && (time < 0f)) {
			Vector3 wordPos;
			Vector3 snappedPos;
			time = clickPause;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit Hit;
			//Track Detection
			if (Physics.Raycast (ray, out Hit, 1000f)) {
				if (Hit.collider.CompareTag ("TrackParts") && blockSel != 3) {
					contact = 1;
				}
				if (Hit.collider.CompareTag ("GroundLayer") && blockSel != 3 && blockSel != 4) {
					contact = 2;
				}
				if (Hit.collider.CompareTag ("Terrain") && blockSel != 4) {
					contact = 3;
				}
				if (Hit.collider.CompareTag ("Veg")) {
					contact = 4;
				}
				if (Hit.collider.CompareTag ("Terrain") && blockSel == 4) {
					contact = 2;
				}
				if (Hit.collider.CompareTag ("TrackSupport") && blockSel != 3 && blockSel != 4) {
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
				Debug.Log ("Track Placed");
			}
			if (contact == 1) {
				Debug.Log ("There is already track here");
			}
			if (contact == 3) {
				Debug.Log ("You must place support first");
			}
			if (contact == 4) {
				Debug.Log ("You must clear the vegetation first");
			}
			//Track & Support Deletion
			if (contact == 5) {
				Destroy (Hit.collider.gameObject);
				Debug.Log ("Object Deleted");
			}
		}
		contact = 0;
	}
}