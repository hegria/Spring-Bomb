using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    float[] bombCooldown = { 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {
        Managers.Input.KeyAction += KeyDown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void KeyDown()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

        }

        if (Input.GetKey(KeyCode.Z))
        {

        }
        else if (Input.GetKey(KeyCode.X))
        {

        }
        else if (Input.GetKey(KeyCode.C))
        {

        }

    }

    void GenBomb(int a)
    {

    }
}