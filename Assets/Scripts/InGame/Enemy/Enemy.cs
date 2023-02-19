using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
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


    public State G_EnemyState
    {
        get
        {
            return EnemyState;
        }
        set
        {
            switch (value)
            {
                case State.Normal:
                    break;
                case State.Ginko:
                    break;
                case State.ChestNut:
                    break;
                case State.KnockBack:
                    break;
            }

            EnemyState = value;
        }
    }

    State EnemyState = State.Normal;
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
        G_EnemyState = State.Normal;
        spr = GetComponent<SpriteRenderer>();
    }

    public void Init(int enemytype)
    {
        speed = System.Convert.ToSingle(Managers.Game.UnitInfo[enemytype]["Speed"]) * Character.character.Speed;
        EnemyType = enemytype;
    }
    void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        StateMachine();
    }

    public void KnockBack(Vector3 target, float knockBackPower, float sturnTime)
    {
        G_EnemyState = State.KnockBack;
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
        G_EnemyState = State.ChestNut;
        nutVelocity = rigidbody.velocity;
        //spr.sprite = Sprite[2];
        Invoke("SetNormal", ChestNutTime);
    }

    float slowamt = 0.5f;
    GinkoRange adj_ginko;
    

    public void Ginko(GinkoRange ginko, float slow)
    {
        G_EnemyState = State.Ginko;
        //spr.sprite = Sprite[3];
        slowamt = slow;

        adj_ginko = ginko;
    }

    public void GinkoOut()
    {
        G_EnemyState = State.Normal;
        adj_ginko = null;
    }


    public void SetNormal()
    {
        //spr.sprite = Sprite[0];
        G_EnemyState = State.Normal;
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
            if (adj_ginko == null)
            {
                G_EnemyState = State.Normal;
                adj_ginko = null;
            }


            dir = Character.character.transform.position - transform.position;
            dir.Normalize();
            rigidbody.MovePosition(rigidbody.position + speed * slowamt * dir * Time.fixedDeltaTime);
            rigidbody.velocity = Vector2.zero;
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
