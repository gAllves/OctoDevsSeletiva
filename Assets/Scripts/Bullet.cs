using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Se a bala colidir com objeto com tag "Wall" ela é destruida
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        
    } 
}
