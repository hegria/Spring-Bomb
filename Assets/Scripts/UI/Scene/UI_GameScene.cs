using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameScene : UI_Scene
{
    enum TMPs
    {
        Wood,
        Enemy1,
        Enemy2,
        Enemy3,
    };


    enum Images
    {
        Boom1,
        Boom2,
        Boom3,
    };

    public override void Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        Bind<TextMeshProUGUI>(typeof(TMPs));
    }

        // Update is called once per frame
    void Update()
    {
        
    }
}
