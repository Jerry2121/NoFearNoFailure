using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject Player;
    public float stamina = 100;

    public void Start()
    {
        PlayerPrefs.SetFloat("Stamina", 100);
    }
    public void Update()
    {
        PlayerPrefs.SetFloat("Stamina", stamina);
        if (PlayerPrefs.GetFloat("Stamina") >= 100)
        {
            stamina = 100;
        }
        if (PlayerPrefs.GetFloat("Stamina") <= 0)
        {
            stamina = 0;
        }
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && Player.GetComponent<OVRPlayerController>().Moving == true)
        {
            stamina -= Time.deltaTime * 2;
            if (stamina <= 0)
            {
                stamina = 0;
                Player.GetComponent<OVRPlayerController>().Acceleration = 0;
            }
        }
        else
        {
            stamina += Time.deltaTime / 2;
            Player.GetComponent<OVRPlayerController>().Acceleration = 0.2f;
        }
    }
}
