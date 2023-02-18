using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    private static Character _character = null;

    public static Character character
    {
        get
        {
            if (null == _character)
            {
                return null;
            }
    
            return _character;
        }
    }
    void Awake()
    {
        if (null == _character)
        {
            _character = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public Rigidbody2D rigid;
    
    float[] bombCooldown = { 0, 0, 0 };
    float[] RealCooldown = { 1, 5, 10 };
    // Start is called before the first frame update
    void Start()
    {
        Managers.Input.KeyAction += KeyDown;
        rigid = GetComponent<Rigidbody2D>();
    }

    [SerializeField]
    Vector2 inputVec;
    [SerializeField]
    float speed;

    bool isThrowing = false;

    public bool bombed = false;
    public Bomb nowbomb = null;

    // Update is called once per frame
    void Update()
    {


        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        for (int i = 0; i < 3; i++)
        {
            bombCooldown[i] = Mathf.Max(bombCooldown[i] - Time.deltaTime, 0);
        }
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
    void FixedUpdate()
    {
        if (isThrowing)
            return;

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }


    void KeyDown()
    {
        Debug.Log("fuck");
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("fuck1");
            GenBomb(1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("fuck12");
            GenBomb(2);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("fuck13");
            GenBomb(3);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isThrowing)
            {
                if (nowbomb == null)
                    isThrowing = false;

                nowbomb.Thrown(inputVec);
                nowbomb = null;
                isThrowing = false;
            }
            else
            {
                if (!bombed)
                    return;

                isThrowing = true;
            }

        }

    }

    void GenBomb(int bombnum)
    {
        if (bombed)
            return;

        if (bombCooldown[bombnum-1] == 0)
        {

            GameObject bomb = Managers.Resource.Instantiate($"Bomb/Bomb{bombnum}", Managers.Game.Bombs.transform);
            bomb.transform.position = transform.position;
            bombed = true;
            nowbomb = bomb.GetComponent<Bomb>();

            bombCooldown[bombnum - 1] = RealCooldown[bombnum - 1];
        }

    }
}