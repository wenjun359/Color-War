using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StatsControll : MonoBehaviour {

    public GameObject gamecontroller;
    public float a=0.01f;
    public string survivedTime;
    public AudioClip lost;
    public bool end=false;

    // Use this for initialization
    void Start () {
       
        



    }
	
	// Update is called once per frame
	void Update () {
        survivedTime = (Mathf.Round(gamecontroller.GetComponent<GameController>().time * 100) / 100).ToString();
        gameObject.transform.GetChild(0).GetComponent<Text>().text = "T I M E : " + survivedTime + " s";
        if (GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor.r < 0.4)
        {
            gameObject.transform.GetChild(0).GetComponent<Text>().color = new Color(1f, 1f, 1f);
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<Text>().color = new Color(0f, 0f, 0f);
        }
        if (a<1f)
        {
            gameObject.transform.GetChild(0).GetComponent<CanvasRenderer>().SetAlpha(a);
            gameObject.transform.GetChild(1).GetComponent<CanvasRenderer>().SetAlpha(a);
            a += 0.01f; 
        }
        if (end)
        {
            fadeOut();
        }

    }

    void fadeOut()
    {
        if (gameObject.GetComponent<AudioSource>().volume>0f)
        {
            gameObject.GetComponent<AudioSource>().volume -= 0.01f;
        }
    }
}
