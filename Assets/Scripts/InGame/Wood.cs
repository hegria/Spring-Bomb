using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDestroy()
    {
        OnDead();
    }

    public virtual void OnDead() { }
}
