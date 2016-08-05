using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour {

    public static float ENEMYSPWANCD = 2.5f;
    public static int MAXENEMY = 30;
    public float enemyspwanCD ;
    public int enemy=0;
    public float time=0;

    public GameObject Enemy;
    public GameObject Bullet;
    public GameObject EnemyControl;
	// Use this for initialization
	void Start () {
        enemyspwanCD = ENEMYSPWANCD;
    }
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;
        if (enemyspwanCD <=0 && enemy <= MAXENEMY)
        {
            enemyspwanCD = ENEMYSPWANCD + Random.Range(0f, 1f) - (time / 6);
            if (enemyspwanCD <= 1f)
            {
                enemyspwanCD = 1f;
            }

            
            Instantiate(Enemy).transform.parent=gameObject.transform;
            if (time > 40)
            {
                Instantiate(Enemy).transform.parent = gameObject.transform;
                enemy += 1;
            }
            if (time > 60)
            {
                Instantiate(Enemy).transform.parent = gameObject.transform;
                enemy += 1;
            }
            enemy += 1;
        }
        else
        {
            enemyspwanCD -= Time.deltaTime;
        }
      

        if (Input.GetKey("escape"))
            Application.Quit();








    }
}
