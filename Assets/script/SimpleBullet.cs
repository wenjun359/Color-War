using UnityEngine;
using System.Collections;


public class SimpleBullet : MonoBehaviour {



    public Rigidbody2D rigid;
    public Vector3 pos;
    public Vector2 space;
    public Vector3 targetPos;
    public float spawntime = 3f;
    public float bulletspeed = 1f;
    public Sprite black, white;
    public bool isPlayer=false;
    public float height, width;


    // Use this for initialization
    void Start () {
        pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos = (pos - transform.position);
        pos = new Vector3(pos.x, pos.y);
        pos = pos.normalized;
        //  rigid = GetComponent<Rigidbody2D> ();
        // rigid.AddForce( pos * bulletspeed);
        height = Screen.height;
        width = Screen.width;
        space = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
       

    }
	

	void Update () {
        if(GameObject.Find("GUIAndStatsControl").GetComponent<StatsControll>().end == false)
        { 
        if (isPlayer)
        {
            transform.Translate(pos * bulletspeed );
        }
        else
        {
            transform.Translate(targetPos * bulletspeed);
        }
        }




        if (transform.position.y > space.y || transform.position.y < -space.y)
        {
            boom();
        }
        if (transform.position.x > space.x || transform.position.x < -space.x)
        {
            boom();
        }






    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBlack")|| other.gameObject.CompareTag("PlayerWhite"))
        {
            boom();
        }
    }

    public void boom()

    {
        gameObject.SetActive(false);
    }

}
