using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigidbody;

    [SerializeField]
    float speed = 0.5f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.AddForce(speed * (Character.character.transform.position - transform.position),ForceMode2D.Impulse);
    }
}
