using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//Reference to the player
	public GameObject player;

	//Offset between the player and the camera
	private Vector3 offset;
	private float offsetY;

	//Variables tracking mouse positions
	float mouseX;
	float mouseY;

	// Use this for initialization
	void Start () {

		//Calculate the offset
		offset = transform.position - player.transform.position;
		offsetY = transform.position.y - player.transform.position.y;
	}
    
	private void FixedUpdate() {

		// Make player obejct look at the camera, while the camera is moving
        Vector3 mousePos = Input.mousePosition;
		Vector3 mouseDir = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;

		player.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg - 90);
        
	}

	// Update is called once per frame after all objects has been transformed
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
