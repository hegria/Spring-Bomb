using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    float Score = 0;

    public GameObject Grounds;
    public GameObject Woods;
    public GameObject Enemys;
    public GameObject Bombs;

    public int Woodnum;
    public int Enemynum;

    public int brokenWood;


    public List<Dictionary<string,object>> UnitInfo;
    public List<Dictionary<string,object>> BombInfo;
    public List<Dictionary<string,object>> TreeInfo;

    public void Init()
    {
        UnitInfo = CSVReader.Read("Unit");
        BombInfo = CSVReader.Read("Bomb");
        TreeInfo = CSVReader.Read("Tree");
    }

    public void Clear()
    {
        Grounds = null;
        Woods = null;
        Enemys = null;
        Bombs = null;
    }

    public void GameInit()
    {
        Score = 0;
        Woodnum = 0;
        Enemynum = 0;

        Grounds = GameObject.Find("Grounds");
        Woods = GameObject.Find("Woods");
        Enemys = GameObject.Find("Enemys");
        Bombs = GameObject.Find("Bombs");
    }

    public void OnUpdate()
    {

    }



    
}
