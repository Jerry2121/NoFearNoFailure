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
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            stamina -= Time.deltaTime * Mathf.Round(10.0f);
            PlayerPrefs.SetFloat("Stamina", stamina);
            if (stamina <= 0)
            {
                stamina = 0;
                Player.GetComponent<OVRPlayerController>().Acceleration = 0;
            }
        }
        else
        {
            Player.GetComponent<OVRPlayerController>().Acceleration = 0.2f;
        }
    }
}
