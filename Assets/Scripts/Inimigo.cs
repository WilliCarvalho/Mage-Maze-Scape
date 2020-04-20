using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    float Speed = 3;
    float vida = 2;
    

    public GameObject Player;
    private Vector3 targetPos;
    public Transform target;
    private Vector3 thisPos;
    private float angle;
    public float offset;

    private bool movimento;
    bool aumento;

    private Rigidbody2D rb;

    void Start()
    {
        movimento = false;
        aumento = false;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
    }


    void Update()
    {
        if(movimento == true)
        {
            transform.LookAt(Player.transform);
            transform.LookAt(target);
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

        if(aumento == true)
        {
            //StartCoroutine(Velocidade());
        }

    }

    void FixedUpdate()
    {
        if (Speed == 7)
        {
            aumento = false;
        }

        
    }

    void LateUpdate()
    {
        targetPos = target.position;
        thisPos = transform.position;

        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;

        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            movimento = true;
            aumento = true;
        }

        else if (c.gameObject.name == "Projetil")
        {
            movimento = true;
            aumento = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {

        if(c.gameObject.tag == "Projetil")
        {
            vida--;
        }

        if (vida == 0)
        {
            Destroy(gameObject);
        }
    }

}
