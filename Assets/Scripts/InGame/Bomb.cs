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

    // Start is called before the first frame update
    void Start()
    {
        starttime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        starttime += Time.deltaTime;

        if (starttime > BombTIme)
        {
            Managers.Resource.Instantiate($"Bomb / Bomb{Explosionnum}");
            Destroy(gameObject);
        }
    }
}
