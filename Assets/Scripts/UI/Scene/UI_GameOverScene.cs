using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_GameOverScene : UI_Scene
{

    enum TMPs
    {
        Score
    }

    // Start is called before the first frame update
    public override void Init()
    {
        base.Init();

        Bind<TextMeshProUGUI>(typeof(TMPs));

        Get<TextMeshProUGUI>((int)TMPs.Score).SetText(
            $"���� ����\n{Managers.Game.brokenWood}�׷縦\n�μ˽��ϴ�");
    }

}
