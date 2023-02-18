using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    protected BoxCollider2D col;
    protected SpriteRenderer spr;
    public Sprite[] img = new Sprite[2];
    
    

    void Awake()
    {
        transform.position += new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));

        col = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spr.sprite = img[0];
    }
    public virtual void OnBoom()
    {
        col.enabled = false;
        spr.sprite = img[1];
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

}
