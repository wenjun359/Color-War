using UnityEngine;
using System.Collections;

public class AbsorbShow : MonoBehaviour {

    

	// Use this for initialization
	void Start () {

        gameObject.SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeInHierarchy == true)
        {
            StartCoroutine(DeActive());
        }
    }



    IEnumerator DeActive()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);

    }
}
