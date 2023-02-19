using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Managers.Sound.Play("Intro", Define.Sound.Bgm);

        Managers.Input.KeyAction += StartVideo;
    }

    public GameObject game;

    void StartVideo()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            game.SetActive(false);
            Managers.UI.ShowSceneUI<UI_VideoScene>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
