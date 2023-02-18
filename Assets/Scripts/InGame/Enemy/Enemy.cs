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
    public Sprite[]  Sprite = new Sprite[4];

    [SerializeField]
    float speed = 0.5f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        EnemyState = State.Normal;
        spr = GetComponent<SpriteRenderer>();

        StartCoroutine("StateMachine");
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
        rigidbody.AddForce((target.position - transform.position).normalized * knockBackPower * Time.deltaTime);
        Invoke("SetNormal", sturnTime);
    }
    
    void SetNormal()
    {
        EnemyState = State.Normal;
    }

    IEnumerator StateMachine()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);

            if(EnemyState == State.KnockBack)
            {
                //spr.sprite = Sprite[1];

            }
            else if(EnemyState == State.ChestNut)
            {
                //spr.sprite = Sprite[2];

            }
            else if (EnemyState == State.Ginko)
            {
                //spr.sprite = Sprite[3];

            }
            else
            {
                //spr.sprite = Sprite[0];
                dir = Character.character.transform.position - transform.position;
                dir.Normalize();
                rigidbody.MovePosition(rigidbody.position + speed * dir * Time.fixedDeltaTime);
                rigidbody.velocity = Vector2.zero;
            }
        }
    }


}
