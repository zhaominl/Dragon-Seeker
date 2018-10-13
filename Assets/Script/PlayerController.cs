using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit {

	//variables used for shooting
	public GameObject bulletPrefab;
	private bool bowCollected;
	private Transform bulletSpawn;


	// Use this for initialization
	public override void Start () {
		bowCollected = false;
	}
    
	// Update is called once per frame
	void Update(){
		//Player shoot
        if (bowCollected)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                bulletSpawn = this.gameObject.transform.GetChild(2);
                shoot();
            }
        }
	}


	void FixedUpdate () {

		// Movement action
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // Make sure the player moves along the global axis, not its local one
		transform.Translate(new Vector3(x, 0, 0), Space.World);
		transform.Translate(new Vector3(0, y, 0), Space.World);


	}

	private void OnTriggerStay(Collider other)
	{
		//If player hit the wall, prevent further movement
		if (other.gameObject.CompareTag("Obstacle")){
			var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            var y = Input.GetAxis("Vertical") * Time.deltaTime * speed;

			transform.Translate(new Vector3(-x, 0, 0), Space.World);
            transform.Translate(new Vector3(0, -y, 0), Space.World);
		}
        
        //Player pick up an item
		else if(other.gameObject.CompareTag("Item")){
			if(Input.GetKeyDown(KeyCode.Space)){
				bowCollected = true;
				other.gameObject.SetActive(false);
			}
		}
	}

	private void shoot() {
		GameObject obj = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
	}
}
