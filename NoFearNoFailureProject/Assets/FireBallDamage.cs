using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDamage : MonoBehaviour {

    public int Health = 25;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Health <= 0) {
            Destroy(gameObject);

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Magic") {
            //Health -= 5;
        }
            
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Magic")
        {
            Health -= 5;
        }

    }
}
