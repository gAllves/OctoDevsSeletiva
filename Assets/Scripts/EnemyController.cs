using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    public GameObject player;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        moveSpeed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        aumentaVelocidade();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
