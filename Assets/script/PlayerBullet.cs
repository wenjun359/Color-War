using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    public Rigidbody2D rigid;
    public Vector3 pos;
    public Vector3 targetPos;
    public float spawntime = 3f;
    public float bulletspeed = 1f;
    public Sprite black, white;
    public bool isPlayer = false;

    // Use this for initialization
    void Start()
    {
        pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos = (pos - transform.position);
        pos = new Vector3(pos.x, pos.y);
        pos = pos.normalized;
        //  rigid = GetComponent<Rigidbody2D> ();
        // rigid.AddForce( pos * bulletspeed);

    }


    void Update()
    {

        if (isPlayer)
        {
            transform.Translate(pos * bulletspeed);

        }
        else
        {
            transform.Translate(targetPos * bulletspeed);
        }
       



    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
