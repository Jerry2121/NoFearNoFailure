using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {
    public GameObject StaminaText;
    public int stamina = 100;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        StaminaText.GetComponent<Text>().text = ("Stamina: " + stamina);
        if (stamina > 100)
        {
            stamina = 100;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            stamina = stamina + 5;
            Destroy(gameObject);
        }
    }
}
