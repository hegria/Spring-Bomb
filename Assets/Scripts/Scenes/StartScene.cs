using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : BaseScene
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1200, 900, false);
        Managers.Sound.Play("Intro", Define.Sound.Bgm);
    }

    public GameObject game;

    void StartVideo()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game.activeSelf &&Input.GetKeyDown(KeyCode.Space))
        {
            game.SetActive(false);
            Managers.Sound.Stop(Define.Sound.Bgm);
            Managers.UI.ShowSceneUI<UI_VideoScene>();
        }
    }

    public override void Clear()
    {

    }
}
