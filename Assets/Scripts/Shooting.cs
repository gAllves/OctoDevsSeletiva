using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;
    public Animator oAnimator;

    public float firerate = 0.4f;
    public float canFire = -1f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > canFire)
        {
            //chama a função de atirar
            Shoot();

            //Ativa a animação de atirar
            oAnimator.SetTrigger("isShooting");
            oAnimator.ResetTrigger("isNotShooting");
        }
        else{

            //Desativa a animação de atirar
            oAnimator.SetTrigger("isNotShooting");
            oAnimator.ResetTrigger("isShooting");
        }
    }

    void Shoot()
    {
        //Cria a bala
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        canFire = Time.time + firerate;

    }
}
