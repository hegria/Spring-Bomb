using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float knockBackPower = 100.0f;
    float sturnTime = 0.5f; 

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Imdead", 1.0f);
    }

    

    public void Init(int Explosionnum)
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
                Managers.Game.brokenWood++;
                Debug.Log("BOM");
                collision.GetComponent<Wood>().OnBoom();
            }
            else if (collision.tag == "Enemy")
            {
                Debug.Log("Ouch");
                collision.GetComponent<Enemy>().KnockBack(transform.position, knockBackPower, sturnTime);
            }
        }
    }

    public void Imdead()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        
    }
}
