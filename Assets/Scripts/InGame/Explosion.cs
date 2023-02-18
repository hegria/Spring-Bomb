using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) { 
            if (collision.tag == "Player")
            {

            }
            else if (collision.tag == "Wood")
            {

            }
            else if (collision.tag == "Enemy")
            {

            }
        }
    }

    void Update()
    {
        
    }
}
