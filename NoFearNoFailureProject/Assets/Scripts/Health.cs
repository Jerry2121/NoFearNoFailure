using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 20);
            Destroy(gameObject);
        }
    }
}
