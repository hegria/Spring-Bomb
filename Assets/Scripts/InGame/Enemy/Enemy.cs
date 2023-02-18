using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    Normal,
    Ginko,
    ChestNut,
    KnockBack
}

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rigidbody;
    State EnemyState;
    Vector2 dir;
    SpriteRenderer spr;

    // 스프라이트 변경 이미지
    public Sprite[] Sprite = new Sprite[4];

    [SerializeField]
    float speed = 0.5f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        EnemyState = State.Normal;
        spr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        StateMachine();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void KnockBack(Transform target, float knockBackPower, float sturnTime)
    {
        EnemyState = State.KnockBack;
        //spr.sprite = Sprite[1];
        rigidbody.AddForce((target.position - transform.position).normalized * knockBackPower * Time.deltaTime);
        Invoke("SetNormal", sturnTime);
    }
    public void ChestNut(float ChestNutTime)
    {
        EnemyState = State.ChestNut;
        //spr.sprite = Sprite[2];
        Invoke("SetNormal", ChestNutTime);
    }
    public void Ginko(float slow)
    {
        //spr.sprite = Sprite[3];
        speed *= slow;
    }


    public void SetNormal()
    {
        //spr.sprite = Sprite[0];
        EnemyState = State.Normal;
    }

    void StateMachine()
    {

        if (EnemyState == State.KnockBack)
        {

        }
        else if (EnemyState == State.ChestNut)
        {
            rigidbody.velocity = rigidbody.velocity;

        }
        else if (EnemyState == State.Ginko)
        {

        }
        else
        {
            dir = Character.character.transform.position - transform.position;
            dir.Normalize();
            rigidbody.MovePosition(rigidbody.position + speed * dir * Time.fixedDeltaTime);
            rigidbody.velocity = Vector2.zero;
        }
    }


}
