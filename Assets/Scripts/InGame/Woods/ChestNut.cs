using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestNut : Wood
{
    public int nutCount = 5;
    [SerializeField]
    private float nutdist = 2f;

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

            float nutPoX = Random.Range(transform.position.x - nutdist, transform.position.x + nutdist);
            float nutPoY = Random.Range(transform.position.y - nutdist, transform.position.y + nutdist);
            GameObject nut = Managers.Resource.Instantiate("Wood/Nut");
            nut.transform.position = new Vector2(nutPoX, nutPoY);
            ++i;
            yield return null;
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
