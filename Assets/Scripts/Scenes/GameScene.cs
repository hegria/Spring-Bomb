using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{

    [SerializeField]
    float genRadius = 10f;

    public override void Clear()
    {
        
    }


    void Start()
    {
        Managers.Game.GameInit();

        GenEnemyForce(1);
        GenEnemyForce(1);
        GenEnemyForce(1);

        Managers.Sound.Play($"Main", Define.Sound.Bgm);

        StartCoroutine("GenEnemy", 1);
        StartCoroutine("GenEnemy", 2);
        StartCoroutine("GenEnemy", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    IEnumerator GenEnemy(int enemynum)
    {
        yield return new WaitUntil(() => Managers.Game.brokenWood > System.Convert.ToSingle(Managers.Game.UnitInfo[enemynum]["Spawn"]));


        while (true)
        {
            int nowbroke = Managers.Game.brokenWood;

            Vector2 Point = Vector2.zero;

            while (true)
            {
                float theta = UnityEngine.Random.Range(0, 2 * Mathf.PI);

                Point = new Vector2(Character.character.transform.position.x + genRadius * Mathf.Cos(theta),
                    Character.character.transform.position.y + genRadius * Mathf.Sin(theta));



                RaycastHit2D hit = Physics2D.CircleCast(Point, 1, Vector2.zero);

                if (hit.collider == null)
                {
                    break;
                }
            }
            GameObject go = Managers.Resource.Instantiate($"Enemy/Enemy{enemynum}", Managers.Game.Enemys.transform);
            go.GetComponent<Enemy>().Init(enemynum);

            go.transform.position = new Vector3(Point.x, Point.y);

            yield return new WaitUntil(() => Managers.Game.brokenWood >= nowbroke + System.Convert.ToSingle(Managers.Game.UnitInfo[enemynum]["Term"]));
        }
    }



    public void GenEnemyForce(int enemynum)
    {
        int nowbroke = Managers.Game.brokenWood;

        Vector2 Point = Vector2.zero;

        while (true)
        {
            float theta = UnityEngine.Random.Range(0, 2 * Mathf.PI);

            Point = new Vector2(Character.character.transform.position.x + genRadius * Mathf.Cos(theta),
                Character.character.transform.position.y + genRadius * Mathf.Sin(theta));



            RaycastHit2D hit = Physics2D.CircleCast(Point, 1, Vector2.zero);

            if (hit.collider == null)
            {
                break;
            }
        }
        GameObject go = Managers.Resource.Instantiate($"Enemy/Enemy{enemynum}", Managers.Game.Enemys.transform);
        go.GetComponent<Enemy>().Init(enemynum);


        go.transform.position = new Vector3(Point.x, Point.y);
    }

}
