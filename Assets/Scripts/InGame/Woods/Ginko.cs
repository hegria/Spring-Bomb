using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ginko : Wood
{
    public int nutCount=5;
    private float radius = 5f;
    public override void OnBoom()
    {
        base.OnBoom();

        
        for (int i = 0; i < nutCount;++i)
        {
            //Nut.transform.position = new Vector3();
            GameObject Nut = Managers.Resource.Instantiate("Wood/Nut");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
