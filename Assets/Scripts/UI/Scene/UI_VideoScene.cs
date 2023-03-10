using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UI_VideoScene : UI_Scene
{
    
    enum VideoPlayers
    {
        RawImage
    }

    public override void Init()
    {
        base.Init();
        Bind<VideoPlayer>(typeof(VideoPlayers));

        Get<VideoPlayer>((int)VideoPlayers.RawImage).loopPointReached += GotoGame;
    }

    public void GotoGame(UnityEngine.Video.VideoPlayer vp)
    {
        Managers.Scene.LoadScene(Define.Scene.Game);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Get<VideoPlayer>((int)VideoPlayers.RawImage).loopPointReached -= GotoGame;

            Managers.Scene.LoadScene(Define.Scene.Game);
        }
    }
}
