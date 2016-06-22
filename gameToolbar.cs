using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameToolbar : MonoBehaviour {
	public GameObject mainCamera;
	public Sprite vert;
	public Sprite horiz;
	public Sprite tunnel;
	public Sprite bridge;
	public Sprite blank;
	public Sprite turn1;
	public Sprite turn2;
	public Sprite turn3;
	public Sprite turn4;

	// Update is called once per frame
	public void Update () {
		CodeBase selection = mainCamera.GetComponent<CodeBase> ();
		Image img = GetComponent<Image> ();
		
		if (selection.blockSel == 1) {
			img.sprite = vert;
		}
		if (selection.blockSel == 2) {
			img.sprite = horiz;
		}
		if (selection.blockSel == 3) {
			img.sprite = tunnel;
		}
		if (selection.blockSel == 4) {
			img.sprite = bridge;
		}
		if (selection.blockSel == 5) {
			img.sprite = turn1;
		}
		if (selection.blockSel == 6) {
			img.sprite = turn2;
		}
		if (selection.blockSel == 7) {
			img.sprite = turn3;
		}
		if (selection.blockSel == 8) {
			img.sprite = turn4;
		}
	}
}