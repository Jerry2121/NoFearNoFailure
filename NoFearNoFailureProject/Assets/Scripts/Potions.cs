using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Potions : MonoBehaviour {
    public GameObject HealthText;
    public GameObject StaminaText;
    public GameObject ManaText;
    public float blah;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetFloat("Mana", 100);
    }

    // Update is called once per frame
    void Update()
    {
        blah = PlayerPrefs.GetFloat("Mana");
        StaminaText.GetComponent<Text>().text = "Stamina: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("Stamina"));
        ManaText.GetComponent<Text>().text = ("Mana: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("Mana")));
        HealthText.GetComponent<Text>().text = ("Health: " + PlayerPrefs.GetInt("Health"));
        if (PlayerPrefs.GetFloat("Mana") >= 100)
        {
            PlayerPrefs.SetFloat("Mana", 100);
        }
        if (PlayerPrefs.GetFloat("Mana") <= 0)
        {
            PlayerPrefs.SetFloat("Mana", 0);
        }
        if (blah >= 100)
        {
            blah = 100;
        }
        if (blah <= 0)
        {
            blah = 0;
        }
        blah += Time.deltaTime / 2;
        PlayerPrefs.SetFloat("Mana", blah);
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
        if (collision.gameObject.tag == "Mana")
        {
            PlayerPrefs.SetFloat("Mana", PlayerPrefs.GetFloat("Mana") + 10);
        }
    }
}
