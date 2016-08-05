using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


    }

    public void startScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Battle");
        


    }
}
