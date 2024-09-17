using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    public GameObject player;
    public LogicScript logic;

    public Animator oAnimator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        //Velocidade inicial do inimigo
        moveSpeed = 4f;
    }
    void Update()
    {
        if(player!=null){
            //Move o inimigo em direção ao player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            //Aumenta a velocidade do inimigo
            aumentaVelocidade();
        }
        else{
            oAnimator.SetTrigger("isIdle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Se colidir com uma bala, destrói o inimigo e a bala e adiciona pontos
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
            logic.addScore();
        }
    }

    public void aumentaVelocidade(){
        if(logic.score >= 15){
            moveSpeed = 5f;
        }

        if(logic.score >= 20){
            moveSpeed = 6f;
        }

        if(logic.score >= 30){
            moveSpeed = 7f;
        }

        if(logic.score >= 40){
            moveSpeed = 8f;
        }

        if(logic.score >= 50){
            moveSpeed = 9f;
        }

        if(logic.score >= 60){
            moveSpeed = 10f;
        }
        
    }
}
