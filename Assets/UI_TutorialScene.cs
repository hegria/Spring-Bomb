using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TutorialScene : UI_Scene
{
    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(gameObject);
        canvas.sortingOrder = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Character.character.isGamePaused&&Input.GetKeyDown(KeyCode.Space))
        {
            Character.character.isGamePaused = false;
            Managers.Game.tutorialed = true;


            Destroy(gameObject);
        }
    }
}
