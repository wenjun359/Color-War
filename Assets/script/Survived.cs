using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Survived : MonoBehaviour {


    public GameObject GameControll;
	// Use this for initialization
	void OnEnable ()
    {
	gameObject.GetComponent<Text>().text= GameControll.GetComponent<StatsControll>().survivedTime + "s";

    }

}
