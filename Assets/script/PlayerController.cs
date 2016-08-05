using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


    public static float BULLETSPEED = 0.1f;
    public static float COLORCHANGECOOLDOWN = 0.1f;
    public GameObject bulletWhite, bulletBlack, absorb;
    public float height, width;
    public Transform tf,tf2;
    public bool onRegenEnergy;
    public AudioClip Beep_Short;
 

    public int energy = 0;
    public int score = 0;
    public float speed = 4f;
    public float atkSpeed = 1f;
    public float atkCount = 0;
    public float colorChangeCD = 0f;
    public float bulletSpeedPara = 1;
    public Sprite black, white;
    public Vector2 boundary;

    public GameObject end1, end2, end3, end4;



    void Start()
    {
        height = Screen.height;
        width = Screen.width;
        boundary = Camera.main.ScreenToWorldPoint(new Vector2(width,height));
        Debug.Log(SystemInfo.deviceType.ToString());
       
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && colorChangeCD<=0)
        {
            ChangeColor();
            colorChangeCD += COLORCHANGECOOLDOWN;
        }

        if (colorChangeCD >0)
        {
            colorChangeCD -= Time.deltaTime;
        }
        if (energy <= 1000 && onRegenEnergy==false)
        {
            onRegenEnergy = true;
            StartCoroutine(RegenEnergy());
        }
        

        Debug.Log(boundary.y.ToString());

        //SetBoundary();

        //Movement for PC

        if (SystemInfo.deviceType.ToString()=="Desktop")
        { 
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.position += move * speed * Time.deltaTime;
        }
        //Movement for Android
        else
        {
            
        }



        if (Input.GetMouseButtonDown(1) && energy >=100)
        {
            foreach (Transform child in tf)
            {
                child.GetComponent<EnemyController>().boom();
            }
            //foreach (Transform child in tf2)
            //{
            //    child.GetComponent<SimpleBullet>().boom();
            //}
            energy = 0; 
            GameObject.Find("EnemySpawnAndBoundary").GetComponent<GameController>().enemy = 0;

        }



















    }

    void FixedUpdate()
    {


        


    }

    //void Shoot(float AtkSpeed,float BulletSpeedPara)
    //{



    //    if (GetComponent<SpriteRenderer>().sprite == white)
    //    {
    //        GameObject obj = Instantiate(bulletWhite, transform.position, Quaternion.identity) as GameObject;
    //        obj.GetComponent<PlayerBullet>().bulletspeed = BULLETSPEED * BulletSpeedPara;
    //        obj.GetComponent<PlayerBullet>().isPlayer = true;

    //    }
    //    else
    //    {
    //        GameObject obj = Instantiate(bulletBlack, transform.position, Quaternion.identity) as GameObject;
    //        obj.GetComponent<PlayerBullet>().bulletspeed = BULLETSPEED * BulletSpeedPara;
    //        obj.GetComponent<PlayerBullet>().isPlayer = true;

    //    }




    //}

    void ChangeColor()
    {
        if (GetComponent<SpriteRenderer>().sprite == white)
        {
            GetComponent<SpriteRenderer>().sprite = black;
            gameObject.tag = "PlayerBlack";

        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = white;
            gameObject.tag = "PlayerWhite";
        }
    }

    void SetBoundary()
    {
        if (gameObject.transform.position.x > boundary.x)
        {
            gameObject.transform.position = new Vector2(boundary.x, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.y > boundary.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, boundary.y);
        }

        if (gameObject.transform.position.x < -boundary.x)
        {
            gameObject.transform.position = new Vector2(-boundary.x, gameObject.transform.position.y);
        }

        if (gameObject.transform.position.y < -boundary.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -boundary.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GetComponent<SpriteRenderer>().sprite == white)
        {
            if (other.gameObject.CompareTag("EnemyBulletBlack"))
            {
                Time.timeScale=0;
                endscreen();
            }

            if (other.gameObject.CompareTag("EnemyBulletWhite"))
            {
                energy += 5;
                absorb.SetActive(true);
                gameObject.GetComponent<AudioSource>().PlayOneShot(Beep_Short, 1f);
            }

            if (other.gameObject.CompareTag("EnemyBlack"))
            {
                Time.timeScale = 0;
                endscreen();

            }

            if (other.gameObject.CompareTag("EnemyWhite"))
            {
                energy += 50;
                absorb.SetActive(true);
                gameObject.GetComponent<AudioSource>().PlayOneShot(Beep_Short, 1f);
                if (energy>=100)
                {
                    score += 10;
                }
                else
                {
                    score += 1;
                }
            }
        }

        if (GetComponent<SpriteRenderer>().sprite == black)
        {
            if (other.gameObject.CompareTag("EnemyBulletBlack"))
            {
                energy += 5;
                absorb.SetActive(true);
                gameObject.GetComponent<AudioSource>().PlayOneShot(Beep_Short, 1f);
            }

            if (other.gameObject.CompareTag("EnemyBulletWhite"))
            {
                Time.timeScale = 0;
                endscreen();
            }


            if (other.gameObject.CompareTag("EnemyBlack"))
            {
                energy += 50;
                absorb.SetActive(true);
                gameObject.GetComponent<AudioSource>().PlayOneShot(Beep_Short, 1f);
                if (energy >= 100)
                {
                    score += 10;
                }
                else
                {
                    score += 1;
                }
            }

            if (other.gameObject.CompareTag("EnemyWhite"))
            {
                Time.timeScale = 0;
                endscreen();
            }
        }
    }


    void endscreen()
    {
        end1.SetActive(true);
        if (GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor.r<0.4)
        {
            end1.GetComponent<Text>().color = new Color(1f,1f,1f);
            end2.GetComponent<Text>().color = new Color(1f, 1f, 1f);
        }
        end2.SetActive(true);
        end3.SetActive(false);
        end4.SetActive(true);
        gameObject.SetActive(false);
        GameObject.Find("GUIAndStatsControl").GetComponent<StatsControll>().end = true;
      
     
        
    }

    IEnumerator RegenEnergy()
    {
        energy += 2;
        yield return new WaitForSeconds(0.1f);
        onRegenEnergy = false;
    }

}
