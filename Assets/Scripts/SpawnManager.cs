using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public GameObject player;
    public int spawnsAtivos = 2;

    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("SpawnEnemy", 2f, 1f);
    }

    public void Update()
    {
        if (player == null)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    public void SpawnEnemy()
    {
        int randomSpawnPoint = Random.Range(0, spawnsAtivos);
        Instantiate(enemyPrefab, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }

    public void acionaSpawn(int spawn){
        spawnsAtivos = spawn;
    }
}
