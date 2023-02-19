using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ginko : Wood
{

    public override void OnBoom() 
    {
        base.OnBoom();
        GinkoRange ginko = Util.FindChild<GinkoRange>(gameObject);
        Destroy(ginko.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
