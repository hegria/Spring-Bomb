using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GinkoRange : MonoBehaviour
{
    public float slow = 0.5f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().Ginko(this,slow);
        }
        if(collision.tag == "Player")
        {
            Character.character.Ginko(this,slow);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.GinkoOut();
        }
        if (collision.tag == "Player")
        {
            Character.character.GinkoOut();
        }
    }
}
