using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour {

	private TextMesh gameOver;

	// Use this for initialization
	void Start () {
		gameOver = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Over(int score, float time){
        time = Mathf.Round(time * 100f) / 100f;
        gameOver.text = "GAME OVER" + "\nScore: " + score + "\nTime: " + time;
	}

    public void Reset(){
        gameOver.text = "";
    }

}
