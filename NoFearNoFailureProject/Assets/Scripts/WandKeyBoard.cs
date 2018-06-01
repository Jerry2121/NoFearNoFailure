using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WandKeyBoard : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float Speed = 6;
    public float Mana = 100;
    public float StartingMana = 100;
    public int ManaBurn = 5;
    public Image ManaBar;
    public float ManaRegen = 1;
    void Start()
    {
        Mana = StartingMana;    
    }

    void Update()
    {

        // var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //  var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        // transform.Rotate(0, x, 0);
        // transform.Translate(0, 0, z);
        if (Mana <= 100)
        {
            Mana += Time.deltaTime * ManaRegen;
        }
        if (Mana >= 100) {
            Mana = 100;
        }
        if (Input.GetButtonDown("Fire1") && Mana >= 0)
        {
            Fire();
            Mana -= ManaBurn;
        }
        ManaBar.fillAmount = Mana / StartingMana;

    }


    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * Speed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}