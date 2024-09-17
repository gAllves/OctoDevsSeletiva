using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;
    public Vector2 movement;
    public Vector2 mousePos;
    public LogicScript logic;
    public Animator oAnimator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    {

        Andar();

        //Movimentação do mouse
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Rotação do player
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        //Flip do player (boneco ficar de cabeça pra baixo = mecanica)
        if (mousePos.x > 0)
        {
            transform.localScale = new Vector3(2f,2f,1);
        }
        else
        {
            transform.localScale = new Vector3(2f,-2f,1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Se colidir com um inimigo, destrói o player e chama a função de game over
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            logic.gameOver();
        }
    }

    void Andar()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Animação
        if (movement.x != 0 || movement.y != 0)
        {
            oAnimator.SetTrigger("isWalking");
            oAnimator.ResetTrigger("isIdle");
        }
        else
        {
            oAnimator.SetTrigger("isIdle");
            oAnimator.ResetTrigger("isWalking");
        }

    }

    
}
