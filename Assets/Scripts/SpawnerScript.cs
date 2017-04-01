﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {
    public float spawnTime;    
    public Transform enemy;
    public Transform player;
    private float lastSpawnTime;

    // Use this for initialization
    void Start()
    {
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        double spawnTime = 3;
        if (Time.time > (spawnTime + lastSpawnTime))
        {
            Transform instantiatedEnemy = Instantiate(enemy, transform.position, transform.rotation);
            EnemyController enemyScript = instantiatedEnemy.GetComponent<EnemyController>();
            enemyScript.player = player;
            lastSpawnTime = Time.time;
        }

    }
}

