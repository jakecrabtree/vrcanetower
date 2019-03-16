using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Rigidbody rb;
    public float speed;
    public float enemyMaxHealth; // might need to make these three floats if it doesn't work
    public float enemyCurrentHealth;
    public float damageAmount = 2;
    public GameObject healthBar;
    public static int enemyDead = 0;
    public EventManager manager;
    private string path = "Particles";
    private GameObject poof;



    public void RemoveHealth()
    {
        float calcHealth = enemyCurrentHealth / enemyMaxHealth; // if cur 80 / 100 = 0.8f
        SetHealthBar(calcHealth);
        enemyCurrentHealth -= damageAmount;
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
    // ------------------------------------------------

    // -------------- Enemy Health Bar ----------------
    public void SetHealthBar(float myHealth)
    {
        //myHealth value 0-1
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
	// Use this for initialization
	void Start () {
        enemyCurrentHealth = enemyMaxHealth;
	}

   

	
	// Update is called once per frame
	void Update () {
    }


    void FixedUpdate()
    {
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime*speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (collision.gameObject.tag == "Tower"){
            TowerController tower = other.transform.parent.GetComponent<TowerController>();
            if (tower != null){
                tower.wasAttacked();
                Destroy(gameObject);
            }
            else{
                Debug.Log("Tower has no TowerController"); 
            }

        }   
        if (collision.gameObject.tag == "Projectile") {
            Destroy (collision.gameObject);
            string currPath = path + Path.DirectorySeparatorChar + "Poof";
            poof = Resources.Load(path) as GameObject;
            Instantiate(poof, gameObject.transform);
            Destroy(gameObject);
            Invoke("DestroyPoof", 1.0f);
            enemyDead++;
        }
    }

    void DestroyPoof(){
        Destroy(poof);
    }


}
