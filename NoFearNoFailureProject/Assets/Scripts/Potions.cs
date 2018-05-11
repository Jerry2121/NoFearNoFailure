using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potions : MonoBehaviour {
    public GameObject StaminaText;
    public int stamina = 100;
    public GameObject ManaText;
    public int mana = 100;
    // Use this for initialization
    void Start()
    {
        mana = 50;
        stamina = 80;
    }

    // Update is called once per frame
    void Update()
    {
        StaminaText.GetComponent<Text>().text = "Stamina: " + stamina;
        if (stamina > 100)
        {
            stamina = 100;
        }
        ManaText.GetComponent<Text>().text = ("Mana: " + mana);
        if (mana > 100)
        {
            mana = 100;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Stamina")
        {
            stamina = stamina + 5;
        }
        if (collision.gameObject.tag == "Health")
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 20);
        }
        if (collision.gameObject.tag == "Player")
        {
            mana = mana + 2;
        }
    }
}
