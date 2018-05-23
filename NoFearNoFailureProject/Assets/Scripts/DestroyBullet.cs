using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemey")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }


    }
}
