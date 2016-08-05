using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Energy : MonoBehaviour {

    public GameObject player;
    public float current,energy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        current = gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount;
        energy = player.GetComponent<PlayerController>().energy;
        energy = energy / 1000f;
        if (current < energy)
        {
            Fill(0.5f);
        }
        if (current > (energy +0.010001f))
        {
            Fill(-2f);
        }


	}

    void Fill(float change)
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount += change / 100;
    }
}
