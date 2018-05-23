using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool Inarea = false;
    public float Speed = 6;
    void Update()
    {
       // var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
      //  var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

       // transform.Rotate(0, x, 0);
       // transform.Translate(0, 0, z);

        if (OVRInput.GetDown(OVRInput.Button.One) && Inarea && PlayerPrefs.GetFloat("Mana") >= 5)
        {
            Fire();
            PlayerPrefs.SetFloat("Mana", PlayerPrefs.GetFloat("Mana") - 5f);
        }
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
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "WandBox")
        {
            Inarea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "WandBox")
        {
            Inarea = false;
        }
    }
}