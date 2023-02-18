using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go;
        int Woodnum = Random.Range(1, 41);
        if (Woodnum <=5)
        {
            go = Managers.Resource.Instantiate("Wood/Ginko", Managers.Game.Woods.transform);
            
        }
        else if (Woodnum <=10)
        {
            go = Managers.Resource.Instantiate("Wood/ChestNut", Managers.Game.Woods.transform);

        }
        else
        {
            go = Managers.Resource.Instantiate("Wood/Wood", Managers.Game.Woods.transform);

        }
        go.transform.position = transform.position;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
