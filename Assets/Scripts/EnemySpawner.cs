using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemySpawner : MonoBehaviour {

    private string[] enemies = {"Orc"};
    private string directoryPath = "Enemies";
    private int minPerWave;
    private int maxPerWave;
    private int waveCount;
    private int xthWaveToIncreaseMin;
    private int xthWaveToIncreaseMax;
    public EventManager manager;

    public float radius = 48.0f;
	// Use this for initialization
	void Start () {
        ResetWaves();
        InvokeRepeating("SpawnWave", 0f, 5f);
        manager.gameOver.AddListener(GameOver);
        manager.gameReset.AddListener(ResetWaves);
	}
	
    void ResetWaves(){
        minPerWave = 1;
        maxPerWave = 3;
        //Should be prime
        xthWaveToIncreaseMin = 11;
        xthWaveToIncreaseMax = 17;
        waveCount = 0;
    }

	// Update is called once per frame
	void Update () {
        
	}

    void GameOver(){
        minPerWave = 0;
        maxPerWave = 0;
    }




    void SpawnWave(){
        waveCount++;
        if (waveCount % xthWaveToIncreaseMin == 0)
        {
            minPerWave++;
        }
        if (waveCount % xthWaveToIncreaseMax == 0)
        {
            maxPerWave++;
        }
        int amtPerWave = Random.Range(minPerWave,maxPerWave);
        HashSet<int> inWave = new HashSet<int>();
        for (int i = 0; i < amtPerWave; i++){
            int deg;
            do
            {
                deg = Random.Range(0, 360);
            }
            while (inWave.Contains(deg));
            inWave.Add(deg);
            float theta = deg * Mathf.Deg2Rad;
            SpawnOnCircle(theta, gameObject.transform.position,radius);
        }
    }
    /*
    void SpawnRandomEnemy(Vector3 center, float r){
        float theta = Random.Range(0, 360) * Mathf.Deg2Rad;
        SpawnOnCircle(theta, center,r);
    }
    */

    void SpawnOnCircle(float theta, Vector3 center, float r){
        float x = center.x + r * Mathf.Sin(theta);
        float y = center.y;
        float z = center.z + r * Mathf.Cos(theta);
        Vector3 spawnPos = new Vector3(x, y, z);
        //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - spawnPos);
        string path = directoryPath + Path.AltDirectorySeparatorChar + enemies[Random.Range(0, enemies.Length)];
        GameObject enemy = Resources.Load(path) as GameObject;
        enemy.transform.position = spawnPos;
        enemy.transform.LookAt(center-spawnPos);
        Instantiate(enemy);
    }
}