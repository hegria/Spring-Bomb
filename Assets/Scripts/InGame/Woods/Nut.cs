using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{

    public Sprite[] sprites;
    
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    public float ChestNutTime = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //collision.GetComponent<Character>().Nut();
            Character.character.ChestNut(ChestNutTime);
            Destroy(gameObject);
        }
        else if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().ChestNut(ChestNutTime);
            Destroy(gameObject);
        }

    }
}
