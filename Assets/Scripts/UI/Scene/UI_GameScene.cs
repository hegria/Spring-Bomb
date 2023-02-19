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
        Get<TextMeshProUGUI>((int)TMPs.Enemy1).SetText(Managers.Game.Enemy1num.ToString());
        Get<TextMeshProUGUI>((int)TMPs.Enemy2).SetText(Managers.Game.Enemy2num.ToString());
        Get<TextMeshProUGUI>((int)TMPs.Enemy3).SetText(Managers.Game.Enemy3num.ToString());

        Get<TextMeshProUGUI>((int)TMPs.Wood).SetText(Managers.Game.brokenWood.ToString());


        GetImage((int)Images.Boom1).fillAmount = Character.character.bombCooldown[0] /
        Character.character.RealCooldown[0];
        
        GetImage((int)Images.Boom2).fillAmount = Character.character.bombCooldown[1] /
        Character.character.RealCooldown[1];

        GetImage((int)Images.Boom3).fillAmount = Character.character.bombCooldown[2] / Character.character.RealCooldown[2];

    }
}
