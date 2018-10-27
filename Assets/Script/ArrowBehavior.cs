using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{

    public float velocity;

    // Use this for initialization
    void Start()
    {
		
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 1, 0) * velocity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
			Destroy(this.gameObject);
        }
		else if(other.CompareTag("Enemy")) {
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
    }
}
