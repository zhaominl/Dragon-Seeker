using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Unit {

	//variables used for shooting
	public GameObject bulletPrefab;
	private bool bowCollected;
	private Transform bulletSpawn;


    public Text hpText;
    private int hp;
    public int dmg;

	// Use this for initialization
	public override void Start () {
		bowCollected = false;
        hp = 100;
        if (dmg <= 0) {
            dmg = 10;
        }
        
        show_hp();
        SC = GameObject.Find("SceneController");
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
        if (hp <= 0) {
            SC.GetComponent<SceneController>().GameOver.Invoke();
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bowCollected = true;
                other.gameObject.SetActive(false);
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            decrease_hp();
            show_hp();
        }
    }

	private void shoot() {
		GameObject obj = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
	}

    public void decrease_hp() {
        hp = hp - dmg;
    }

    public void increase_hp() {
        hp = hp + dmg;
    }

    public void show_hp() {
        hpText.text = "HP: " + hp.ToString();
    }
}
