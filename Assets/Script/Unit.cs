using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour {

	//Unit move speed
	public float speed;

    //gameOver event variables
	public UnityEvent gameOver;
	private GameObject SceneController;

	// Use this for initialization
	public virtual void Start () {
        
		if(gameOver == null){
			gameOver = new UnityEvent();
		}
        
		SceneController = GameObject.Find("SceneController");
		gameOver.AddListener(SceneController.GetComponent<SceneController>().gameOver);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
