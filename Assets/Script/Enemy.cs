using UnityEngine;

public class Enemy : Unit {

	public GameObject player;

	// Use this for initialization
	public override void Start () {

		base.Start();
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
