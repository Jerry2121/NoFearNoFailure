using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potions : MonoBehaviour {
    public GameObject StaminaText;
    public GameObject ManaText;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("Mana", 100);
    }

    // Update is called once per frame
    void Update()
    {
        StaminaText.GetComponent<Text>().text = "Stamina: " + PlayerPrefs.GetFloat("Stamina");
        if (PlayerPrefs.GetFloat("Stamina") >= 100)
        {
            PlayerPrefs.SetFloat("Stamina", 100);
        }
        if (PlayerPrefs.GetFloat("Stamina") <= 1)
        {
            PlayerPrefs.SetFloat("Stamina", 0);
        }
        ManaText.GetComponent<Text>().text = ("Mana: " + PlayerPrefs.GetInt("Mana"));
        if (PlayerPrefs.GetInt("Mana") >= 100)
        {
            PlayerPrefs.SetInt("Mana", 100);
        }
        if (PlayerPrefs.GetInt("Mana") <= 1)
        {
            PlayerPrefs.SetInt("Mana", 0);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Stamina")
        {
            PlayerPrefs.SetFloat("Stamina", PlayerPrefs.GetFloat("Stamina") + 50);
        }
        if (collision.gameObject.tag == "Health")
        {
            PlayerPrefs.SetInt("Health", PlayerPrefs.GetInt("Health") + 20);
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("Mana", PlayerPrefs.GetInt("Mana") + 10);
        }
    }
}
