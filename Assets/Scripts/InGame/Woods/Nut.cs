using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    public float ChestNutTime = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //collision.GetComponent<Character>().Nut();
            Destroy(gameObject);
        }
        else if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().ChestNut(ChestNutTime);
            Destroy(gameObject);
        }

    }
}
