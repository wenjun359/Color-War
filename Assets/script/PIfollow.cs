using UnityEngine;
using System.Collections;

public class PIfollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = gameObject.GetComponentInParent<Transform>().position;
	}
}
