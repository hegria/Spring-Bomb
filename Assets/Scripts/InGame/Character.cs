using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;



public class Character : MonoBehaviour
{
    private static Character _character = null;

    public State G_PlayerState
    {
        get
        {
            return PlayerState;
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

            PlayerState = value;
        }
    }

    State PlayerState = State.Normal;


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
    float[] RealCooldown = { 0, 0, 0 };

    // Start is called before the first frame update

    void Start()
    {
        Managers.Input.KeyAction += KeyDown;
        rigid = GetComponent<Rigidbody2D>();
        RealCooldown[0] = System.Convert.ToSingle(Managers.Game.BombInfo[0]["Cooldown"]);
        RealCooldown[1] = System.Convert.ToSingle(Managers.Game.BombInfo[1]["Cooldown"]);
        RealCooldown[2] = System.Convert.ToSingle(Managers.Game.BombInfo[2]["Cooldown"]);
    }

    [SerializeField]
    Vector2 inputVec;
    public float Speed = 2f;

    public bool bombed = false;
    public Bomb nowbomb = null;


    public void SetNormal()
    {
        //spr.sprite = Sprite[0];
        G_PlayerState = State.Normal;
    }


    // Update is called once per frame
    void Update()
    {


        switch (PlayerState)
        {
            case State.Normal:
                inputVec.x = Input.GetAxisRaw("Horizontal");
                inputVec.y = Input.GetAxisRaw("Vertical");
                break;
            case State.ChestNut:
                inputVec.x = Input.GetAxisRaw("Horizontal");
                inputVec.y = Input.GetAxisRaw("Vertical");
                break;

            case State.Ginko:
                break;
        }
        for (int i = 0; i < 3; i++)
        {
            bombCooldown[i] = Mathf.Max(bombCooldown[i] - Time.deltaTime, 0);
        }
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
    void FixedUpdate()
    {
        switch (PlayerState)
        {
            case State.Normal:
                {
                    Vector2 nextVec = inputVec.normalized * Speed * Time.fixedDeltaTime;
                    rigid.MovePosition(rigid.position + nextVec);
                }
                break;
            case State.ChestNut:
                break;

            case State.Ginko:
                break;

            case State.KnockBack:
                break;
        }


    }


    void KeyDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GenBomb(1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            GenBomb(2);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GenBomb(3);
        }
    }

    void GenBomb(int bombnum)
    {
        if (bombed)
            return;

        if (bombCooldown[bombnum-1] == 0)
        {
            Managers.Sound.Play($"Launch{bombnum}");
            GameObject bomb = Managers.Resource.Instantiate($"Bomb/Bomb{bombnum}", Managers.Game.Bombs.transform);
            bomb.GetComponent<Bomb>().Init(bombnum);
            bomb.transform.position = transform.position;
            bombed = true;
            nowbomb = bomb.GetComponent<Bomb>();

            bombCooldown[bombnum - 1] = RealCooldown[bombnum - 1];
        }

    }
}