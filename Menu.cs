using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public bool runtrain;
	
	public void StartGame () {
		SceneManager.LoadScene ("base");
	}

	public void EndGame () {
		Application.Quit ();
	}

	public void HelpMe () {
		SceneManager.LoadScene ("help");
	}

	public void ReturnToMenu () {
		SceneManager.LoadScene ("menuscene");
	}

	/*public void runTrain(){
		if (!runtrain) {
			runtrain = true;
			Debug.Log ("Run Train");
		} else if (runtrain) {
			runtrain = false;
			Debug.Log ("Stop Train");
		}
	}*/
	public void winGame(){
		SceneManager.LoadScene ("winScene");
	}
}