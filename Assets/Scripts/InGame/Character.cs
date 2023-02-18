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

    Vector2 inputVec;
    [SerializeField]
    float speed;

    bool isThrowing;

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        for (int i = 0; i < 3; i++)
        {
            bombCooldown[i] = Mathf.Min(bombCooldown[i] - Time.deltaTime, 0);
        }
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    public bool bombed = false;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!bombed)
                return;

        }

    }

    void GenBomb(int bombnum)
    {
        if (bombed)
            return;

        Managers.Resource.Instantiate($"Bomb/Bomb{bombnum}");

        bombed = true;
    }
}