using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public GameObject player;
    public int spawnsAtivos = 2;

    public void Start()
    {
        //Encontra o player
        player = GameObject.FindGameObjectWithTag("Player");

        //Spawn os inimigos a cada 1 segundo e espera 2 segundos para começar
        InvokeRepeating("SpawnEnemy", 2f, 1f);
    }

    public void Update()
    {
        //Se o player morrer, para de spawnar inimigos
        if (player == null)
        {
            CancelInvoke("SpawnEnemy");
        }
    }

    public void SpawnEnemy()
    {
        //Sorteia um spawn point entre 0 e o número de spawns ativos
        int randomSpawnPoint = Random.Range(0, spawnsAtivos);

        //Instancia um inimigo no spawn point sorteado
        Instantiate(enemyPrefab, spawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }

    //Função que ativa os spawns
    public void acionaSpawn(int spawn){
        spawnsAtivos = spawn;
    }
}
