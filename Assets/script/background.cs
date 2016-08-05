using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {
    Camera ca;
    float duration=4f;
    public Color color1, color2;
    // Use this for initialization
    void Start () {
       ca = GetComponent<Camera>();
        color1 = new Color(0.0f, 0.0f, 0.0f);
        color2 = new Color(1f, 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {

        float t = (Mathf.Sin(Time.time/2)+1)/2;
        ca.backgroundColor = Color.Lerp(color1, color2, t);
    }
}
