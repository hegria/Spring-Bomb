using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : BaseScene
{
    public override void Clear()
    {

    }

    protected override void Init()
    {
        base.Init();
        Managers.Sound.Play("End", Define.Sound.Bgm, volumn:1.2f);

        Managers.UI.ShowSceneUI<UI_GameOverScene>();

        Managers.Input.KeyAction += GotoMain;
    }

    void GotoMain()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Managers.Scene.LoadScene(Define.Scene.Game);
    }
}

