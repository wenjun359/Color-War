using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour {

    public Sprite black, white;
    public GameObject EnemyBulletWhite, EnemyBulletBlack,GameControl;
    public GUIText StatsControl;
    public GameObject bullet,player;
    public float speed = 4f;
    public static float BULLETSPEED = 0.1f;
    public float BulletSpeedPara = 1;
    public static float FIRERATE = 0.6f;
    public float fireRate=2f;
    public float rnd;
    public float followSpeed;
    public bool allowFollow=false;
    public List<GameObject> whiteBullets,blackBullets;
    public int pooledAmount = 20;
    public bool willGrow = true;

    // Use this for initialization
    void Start () {
        float testHeight = Screen.height;
        float testWidth = Screen.width;
        Vector2 screenSize = Camera.main.ScreenToWorldPoint(new Vector2(testWidth, testHeight));
        float x = Random.Range(-screenSize.x+1, screenSize.x-1);
        float y = Random.Range(-screenSize.y+1, screenSize.y-1);
        
        while (x>-screenSize.x+2 && x < screenSize.x - 2 && y > -screenSize.y + 2 && y < screenSize.y - 2)
        {
            x = Random.Range(-screenSize.x+1, screenSize.x-1);
            y = Random.Range(-screenSize.y+1, screenSize.y-1);
        }
        transform.position = new Vector3(x,y);
        rnd = Random.Range(0, 2);
        if (rnd != 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = white;
            gameObject.tag = "EnemyWhite";
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = black;
            gameObject.tag = "EnemyBlack";
        }
        
        if (Random.Range(0, 2) != 0)
        {
            allowFollow = true;
        }
       
        bullet = GameObject.Find("Bullet");
        BulletSpeedPara = BULLETSPEED * Random.Range(1f, 2f);

        player = GameObject.Find("Player");
        followSpeed = Random.Range(0.01f, 0.12f);

    
    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("Player")!=null)
        { 
        if (gameObject.transform.position.x < 100)
        {
            if (fireRate <= 0)
            {
                fireRate = FIRERATE;
                shoot();
            }
            else
            {
                fireRate -= Time.deltaTime;
            }
        }
        if(allowFollow)
        {
            follow();
        }
        }




    }



    void shoot()
    {
        if (GetComponent<SpriteRenderer>().sprite == white)
        {
            GameObject obj;
            obj= gameObject.GetComponent<EnemyController>().ReUseBullet(EnemyBulletWhite,true);
            if (obj!=null)
            {
                Vector3 position = GameObject.Find("Player").transform.position - this.gameObject.transform.position;
                obj.transform.parent = bullet.transform;
                obj.transform.position = gameObject.transform.position;
                obj.GetComponent<SimpleBullet>().targetPos = position.normalized;
            }

        }
        else
        {
            GameObject obj;
            obj = gameObject.GetComponent<EnemyController>().ReUseBullet(EnemyBulletBlack, false);
            if (obj != null)
            {
                Vector3 position = GameObject.Find("Player").transform.position - this.gameObject.transform.position;
                obj.transform.parent = bullet.transform;
                obj.transform.position = gameObject.transform.position;
                obj.GetComponent<SimpleBullet>().targetPos = position.normalized;
            }
        }

        
    }

    void follow()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position,followSpeed );
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<SpriteRenderer>().sprite == white)
        {
            if (other.gameObject.CompareTag("PlayerWhite"))
            {
                
                gameObject.SetActive(false);
                gameObject.GetComponentInParent<GameController>().enemy -= 1;

            }

        }

        if (GetComponent<SpriteRenderer>().sprite == black)
        {

            if (other.gameObject.CompareTag("PlayerBlack"))
            {
                gameObject.SetActive(false);
                gameObject.GetComponentInParent<GameController>().enemy -= 1;
            }
        }
    }

    public void boom()
    {
        gameObject.SetActive(false);
    }

    public GameObject ReUseBullet(GameObject pooledObj,bool white)
    {
        if (white)
        { 
        for (int i = 0; i < whiteBullets.Count; i++)
        {
            if (!whiteBullets[i].activeInHierarchy)
            {
                return whiteBullets[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(pooledObj);
            whiteBullets.Add(obj);
            return obj;
        }
        }
        else
        {
            for (int i = 0; i < blackBullets.Count; i++)
            {
                if (!blackBullets[i].activeInHierarchy)
                {
                    blackBullets[i].SetActive(true);
                    return blackBullets[i];
                }
            }
            if (willGrow)
            {
                GameObject obj = (GameObject)Instantiate(pooledObj);
                blackBullets.Add(obj);
                return obj;
            }
        }
        return null;

    }
}
