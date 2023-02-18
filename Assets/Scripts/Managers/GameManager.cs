using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    float Score = 0;

    public GameObject Grounds;
    public GameObject Woods;
    public GameObject Enemys;
    public GameObject Bombs;

    int Woodnum;
    int Enemynum;

    int brokenWood;

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

    IEnumerator GenEnemy1()
    {
        yield return new WaitUntil(() => Woodnum > 20);
    }

    IEnumerator GenEnemy2()
    {
        yield return new WaitUntil(() => Woodnum > 30);
    }
    IEnumerator GenEnemy3()
    {
        yield return new WaitUntil(() => Woodnum > 50);
    }

    public void OnUpdate()
    {

    }


    
}
