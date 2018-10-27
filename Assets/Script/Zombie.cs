using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie :  Enemy{

    
	// Use this for initialization
	public override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate(){

        // Zombie chase after the player

        // Change the direction to player
		Vector3 playerDir = player.transform.position - transform.position;
		transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg - 90);

        // Move toward player
		transform.Translate(Vector3.Normalize(playerDir) * Time.deltaTime * speed,Space.World);
	}
}
