﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<Cyclop>().ATTACK();
        }
    }
    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<Cyclop>().notATTACK();
        }
    }

}
