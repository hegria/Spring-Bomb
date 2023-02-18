using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestNut : Wood
{
    public int nutCount = 5;
    private float radius = 5f;

    public override void OnBoom()
    {
        base.OnBoom();

        StartCoroutine("NutCreate");
        
    }
    IEnumerator NutCreate()
    {
        int i = 0;


        while (i < nutCount)
        {
            float nutPoX = Random.Range(transform.position.x - 10f, transform.position.x + 10f);
            float nutPoY = Random.Range(transform.position.y - 10f, transform.position.y + 10f);
            Vector2 nutPo = new Vector2(nutPoX, nutPoY);
            if (Vector2.Distance(transform.position, nutPo) < radius)
            {
                Managers.Resource.Instantiate("Wood/Nut");
                ++nutCount;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
