using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projetil : MonoBehaviour
{
    private float velocidade = 10;

    private float velocidadeX, velocidadeY;
    private Rigidbody2D rb;

    private int limite = 30;

    void Start()
    {
        velocidadeX = velocidade / 2;
        velocidadeY = velocidade;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
        rb.AddForce(Vector2.up * velocidadeY);
    }

    void Update()
    {
        transform.Translate(Vector2.up * velocidade * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Destroy(gameObject);
    }

}
