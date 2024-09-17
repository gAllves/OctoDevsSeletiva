using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public int score = 0;
    public SpawnManager spawnManager;  

    public void Start(){
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }
    public void Update(){
        gameChanging();
    }
    
    //Restarta o jogo
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Ativa a tela de Game Over
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    //Adiciona pontos ao score
    public void addScore(){
        score++;
    }
    public void gameChanging(){
        
        if(score == 5){

            //Destroy a parede de cima
            Destroy(GameObject.FindGameObjectWithTag("PortaCima"));

            //Aciona os spawns de cima
            spawnManager.acionaSpawn(4);
        }

        if(score == 10){

            //Destroi a parede da direita
            Destroy(GameObject.FindGameObjectWithTag("PortaDireita"));

            //Aciona os spawns da direita
            spawnManager.acionaSpawn(6);
        }
    }
}
