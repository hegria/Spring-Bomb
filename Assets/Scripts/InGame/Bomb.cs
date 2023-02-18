using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    float BombTIme = 1.0f;
    [SerializeField]
    int Explosionnum = 1;
    
    float starttime  = 0.0f;

    float Force = 300f;

    // Start is called before the first frame update
    void Start()
    {
        starttime = 0;
        
    }


    public void Init(int explosionnum)
    {
        Explosionnum = explosionnum;
        BombTIme = System.Convert.ToSingle(Managers.Game.BombInfo[Explosionnum - 1]["ReadyTime"]);
    }

    // Update is called once per frame
    void Update()
    {
        starttime += Time.deltaTime;

        if (starttime > BombTIme)
        {
            Managers.Sound.Play($"Explosion{Explosionnum}");

            GameObject go = Managers.Resource.Instantiate($"Explosion/Explosion{Explosionnum}");
            go.GetComponent<Explosion>().Init(Explosionnum);
            go.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Character.character.bombed = false;
        GetComponent<CircleCollider2D>().isTrigger = false;
    }

    public void Thrown(Vector2 vec)
    {
        GetComponent<Rigidbody2D>().AddForce(vec.normalized * Force);
    }

}
