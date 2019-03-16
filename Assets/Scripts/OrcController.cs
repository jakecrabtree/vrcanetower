using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : EnemyController {

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        speed = 1f;
        manager = GameObject.Find("EventManager").GetComponent<EventManager>();
        manager.gameOver.AddListener(Stop);
        manager.gameReset.AddListener(DestroyMe);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DestroyMe()
    {
        Destroy(gameObject);
    }

    void Stop()
    {
        speed = 0f;
    }
}
