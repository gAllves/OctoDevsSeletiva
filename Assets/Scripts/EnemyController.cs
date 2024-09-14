using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    public bool estaNaPorta = false;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(estaNaPorta == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-6.0f, 0f), moveSpeed * Time.deltaTime);
        }

        if(transform.position.x == -6.0f)
        {
            estaNaPorta = true;
        }

        if (player != null && estaNaPorta)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
