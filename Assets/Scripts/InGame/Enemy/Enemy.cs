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
    Vector2 nutVelocity;

    public int EnemyType = 0;

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

    public void Init(int enemytype)
    {
        speed = System.Convert.ToSingle(Managers.Game.UnitInfo[enemytype]["Speed"]) * Character.character.Speed;
        EnemyType = enemytype;
    }
    void Update()
    {
        StateMachine();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void KnockBack(Vector3 target, float knockBackPower, float sturnTime)
    {
        EnemyState = State.KnockBack;
        //spr.sprite = Sprite[1];
        rigidbody.velocity = Vector2.zero;
        float sturnt = sturnTime;
        if (EnemyType != 1)
            sturnt *= 0.5f;
        rigidbody.AddForce((transform.position - target).normalized * knockBackPower);
        Invoke("SetNormal", sturnt);
    }

    public void ChestNut(float ChestNutTime)
    {
        EnemyState = State.ChestNut;
        nutVelocity = rigidbody.velocity;
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
            rigidbody.MovePosition(rigidbody.position + speed * dir * Time.fixedDeltaTime);
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
