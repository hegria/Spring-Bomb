using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float knockBackPower = 5.0f;
    public float sturnTime = 0.5f; 

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
                //collision.GetComponent<Character>().Die();
            }
            else if (collision.tag == "Wood")
            {
                collision.GetComponent<Wood>().OnDestroy();
            }
            else if (collision.tag == "Enemy")
            {
                collision.GetComponent<Enemy>().KnockBack(transform, knockBackPower, sturnTime);
            }
        }
    }

    void Update()
    {
        
    }
}
