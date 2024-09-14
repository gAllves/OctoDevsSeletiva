using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("SpawnEnemy", 1f, 1.5f);
    }

    void Update()
    {
        if (player == null)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    void SpawnEnemy()
    {
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }
}
