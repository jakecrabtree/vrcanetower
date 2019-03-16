using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTint : MonoBehaviour {

    private Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        light.color = Color.Lerp(light.color, Color.white, Mathf.PingPong(Time.time, 1));
	}

    public void TakeDamage(){
        light.color = Color.red;
    }

    public void FadeToBlack(){
        light.color = Color.black;
    }

}
