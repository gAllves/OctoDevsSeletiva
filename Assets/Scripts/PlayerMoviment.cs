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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Movimentação do mouse
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //Movimentação do player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Rotação do player
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        //Flip do player
        if (mousePos.x > 0)
        {
            transform.localScale = new Vector3(0.1f,0.045f,1);
        }
        else
        {
            transform.localScale = new Vector3(0.1f,-0.045f,1);
        }
    }

    
}
