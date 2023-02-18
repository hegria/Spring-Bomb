using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    float Score = 0;

    GameObject Grounds;
    GameObject Woods;
    GameObject Enemys;
    GameObject Bombs;

    int Woodnum;
    int Enemynum;

    public void Init()
    {
        Score = 0;

        Grounds = GameObject.Find("Grounds");
        Woods = GameObject.Find("Woods");
        Enemys = GameObject.Find("Enemys");
        Bombs = GameObject.Find("Bombs");

        Woodnum = 0;
        Enemynum = 0;
    }

    public void OnUpdate()
    {

    }


    
}
