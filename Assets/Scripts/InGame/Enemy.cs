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
        Vector2 dir = Character.character.rigid.position - rigidbody.position;
        dir.Normalize();

        rigidbody.MovePosition(rigidbody.position + speed * dir * Time.fixedDeltaTime);
        rigidbody.velocity = Vector2.zero;  
    }
}
