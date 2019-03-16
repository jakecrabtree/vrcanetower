using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileControls : MonoBehaviour {

	private GameObject projectile;
	public GameObject[] projectiles = new GameObject[7];
	private int projectile_index;
    public GameObject spawnPos;
    public int velocity;
    private bool startTouch;
    public EventManager manager;
    bool gameOver = false;

	private Vector2 scrollInit, scrollStop;

	// Use this for initialization
	void Start () {
		projectiles[0] = (GameObject)Resources.Load("Projectiles/Asteroid");
		projectiles[1] = (GameObject)Resources.Load("Projectiles/Arrow_Regular");
		projectiles[2] = (GameObject)Resources.Load("Projectiles/Bomb");
		projectiles[3] = (GameObject)Resources.Load("Projectiles/ChickenBrown");
		projectiles[4] = (GameObject)Resources.Load("Projectiles/CowBlW");
		projectiles[5] = (GameObject)Resources.Load("Projectiles/Shield");
		projectiles[6] = (GameObject)Resources.Load("Projectiles/Sword"); 
		projectile_index = 0;
        velocity = 25;
        startTouch = true;
        manager.gameOver.AddListener(GameOver);
	}
	
    void GameOver(){
        gameOver = true;
    }

	// Update is called once per frame
	void Update () {
        if (GvrControllerInput.ClickButtonDown && gameOver){
            gameOver = false;
            manager.gameReset.Invoke();
        }
		else if (GvrControllerInput.ClickButtonDown){
            projectile = Instantiate(projectiles[projectile_index], spawnPos.transform.position, spawnPos.transform.rotation);
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(GvrControllerInput.Orientation * Vector3.forward * velocity, ForceMode.VelocityChange);
            Destroy(projectile,5f);
		}

        if (GvrControllerInput.TouchDown){
            scrollInit = GvrControllerInput.TouchPosCentered;
		}

        if (GvrControllerInput.IsTouching){
            scrollStop = GvrControllerInput.TouchPosCentered;
        }

		if (GvrControllerInput.TouchUp){
            if (scrollStop.x - scrollInit.x > 0){
				projectile_index = (projectile_index + 1) % 7;
                if (projectile_index >= 6)
                {
                    projectile_index = 6;
                }
            } else if (scrollStop.x - scrollInit.x < 0){
				projectile_index = (projectile_index - 1) % 7;
                if (projectile_index < 0){
                    projectile_index = 0;
                }
            }
		}
	}
}
