using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Shooting1 : MonoBehaviour {


	public GameObject prefab;
    public GameObject prefab2;
	public float bulletSpeed = 10f;
	public float bulletLifetime = 1.0f;
	public float shootDelay = 0.1f;
	private float timer = 0f;
    public float attack2delay = 60f;
    public float timer2 = 0f;
	// Use this for initialization
	void Start () {
		timer = shootDelay;
        timer2 = attack2delay;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButtonDown ("Fire1") && timer >= shootDelay) {
			//get the mouse position
			var mousePosition = Input.mousePosition;
			//convert the mouse position from pixels to x,y values in the game
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
			//create the shoot direction, which is calculated by mousePosition - playerPosition
			Vector3 shootDirection = new Vector3 (mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
			//create the bullet object

			//reduce the length of the direction to 1, so it is always the same regardless of how far away
			//the mouse is from the player. 
			shootDirection.Normalize();

			Vector3 spawnPosition = transform.position;
			spawnPosition.x += shootDirection.x * 0.2f;
			spawnPosition.y += shootDirection.y * 0.2f;

			//create the object in front of the player
			GameObject bullet = (GameObject)Instantiate (prefab, spawnPosition, Quaternion.identity);
			//apply the velocity in the shoot direction
			bullet.GetComponent<Rigidbody> ().velocity = shootDirection * bulletSpeed;
			prefab.GetComponent<AudioSource> ().Play ();
			Destroy (bullet, bulletLifetime);
			timer = 0;
		}

        timer2 += Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && timer2 >= attack2delay)
        {

            //get the mouse position
            var mousePosition = Input.mousePosition;
            //convert the mouse position from pixels to x,y values in the game
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //create the shoot direction, which is calculated by mousePosition - playerPosition
            Vector3 shootDirection = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            //create the attack2 object

            //reduce the length of the direction to 1, so it is always the same regardless of how far away
            //the mouse is from the player. 
            shootDirection.Normalize();

            Vector3 spawnPosition = transform.position;
            spawnPosition.x += shootDirection.x * 0.2f;
            spawnPosition.y += shootDirection.y * 0.2f;

            //create the object in front of the player
            GameObject attack2 = (GameObject)Instantiate(prefab2, spawnPosition, Quaternion.identity);
            //apply the velocity in the shoot direction
            attack2.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
			prefab.GetComponent<AudioSource> ().Play ();
            Destroy(attack2, bulletLifetime);
            timer2 = 0;
        }
    }
}
