using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour {
    public GameObject ManaText;
    public int mana = 100;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        ManaText.GetComponent<Text>().text = ("Mana: " + mana);
        if (mana > 100)
        {
            mana = 100;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            mana = mana + 2;
            Destroy(gameObject);
        }
    }
}
