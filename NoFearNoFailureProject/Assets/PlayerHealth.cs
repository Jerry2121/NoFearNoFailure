using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    public float Health = 100;
    public float StartingHealth = 100;
    public Image HealthBar;
    public float HealthRegen = 1;

    // Use this for initialization
    void Start () {
        Health = StartingHealth;

    }

    // Update is called once per frame
    void Update () {
        if (Health <= 100)
        {
            Health += Time.deltaTime * HealthRegen;
        }
        if (Health <= 0) {

            Debug.Log("You are Dead");
        }
        HealthBar.fillAmount = Health / StartingHealth;

    }
}
