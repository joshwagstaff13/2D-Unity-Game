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
	}
}