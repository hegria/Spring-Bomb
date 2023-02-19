using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMinimap : MonoBehaviour
{
    Transform charTr;
    // Start is called before the first frame update
    void Start()
    {
        charTr = Character.character.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float clampX = Mathf.Clamp(charTr.position.x, -53f, 53f);
        float clampY = Mathf.Clamp(charTr.position.y, -35f, 40f);
        transform.position = new Vector3(clampX, clampY, -10);
    }
}
