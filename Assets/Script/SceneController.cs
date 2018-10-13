using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// referece of the UI object when game over
	public GameObject loseText;
	public GameObject restartButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Function called by gameOver event 
	public void gameOver() {

		loseText.SetActive(true);
		restartButton.SetActive(true);

		//Everything except Update() and button functions will be paused
		Time.timeScale = 0;
	}

    //Function called by restart button
	public void restartGame() {

		SceneManager.LoadScene("MainScene");
		Time.timeScale = 1;
	}
}
