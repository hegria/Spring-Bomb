using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Managers.Resource.Instantiate($"Forest/Forest{Random.Range(1, 5)}");
        go.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
