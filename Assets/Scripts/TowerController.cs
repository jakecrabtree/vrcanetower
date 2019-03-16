using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    private int maxHealth;
    private int currentHealth;
    public HealthBanner banner;
    public DamageTint tint;
    public GameOver gameover;
    public EventManager manager;
    private float time;

	// Use this for initialization
	void Start () {
        maxHealth = 10;
        Reset();
        manager.gameReset.AddListener(Reset);
       // gameover.Over();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Reset(){
        currentHealth = maxHealth;
        banner.setText(currentHealth);
        time = Time.time;
        gameover.Reset();
    }


    public void wasAttacked(){
        currentHealth--;
        if (currentHealth<= 0){
            tint.FadeToBlack();
            manager.gameOver.Invoke();
            gameover.Over(EnemyController.enemyDead, Time.time-time);
            Debug.Log("Game Over");
        }
        if (currentHealth >= 0){
            banner.setText(currentHealth);
            tint.TakeDamage();
        }
    }

    public void FadeToBlack()
    {

    }
}
