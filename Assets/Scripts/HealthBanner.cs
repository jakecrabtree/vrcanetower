using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBanner : MonoBehaviour {

    private TextMesh text;
	// Use this for initialization
	void Start () {
        text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void setText(int health){
        text.text = health.ToString();
    }

}
