using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    public GameObject musicaBoss;

    float Speed = 5;
    float vida = 30;

    //Atirar no jogador
    public GameObject Player;
    public Transform Alvo;
    public GameObject AtaquePrefab;

    //Definir movimento
    public GameObject Sensor1;
    public GameObject Sensor2;
    private Vector3 targetPos;
    public Transform target;
    public Transform target2;
    private Vector3 thisPos;
    private float angle;
    public float offset;

    private bool movimento;

    private Rigidbody2D rb;

    //definir animações
    private Animator animacao;


    //-------------------------------------------------------------//Definições//-------------------------------------------------------------//
    void Start()
    {
        movimento = false;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;

        animacao = GetComponent<Animator>();
    }

    //-------------------------------------------------------------//Faz o BOSS identificcar a posição do proximo sensor//-------------------------------------------------------------//
    void Update()
    {
        if (movimento == true)
        {
            transform.LookAt(Sensor1.transform);
            transform.LookAt(target);
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

        if(vida == 10)
        {
            animacao.SetBool("KillMode", true);
        }

    }
    //-------------------------------------------------------------//seguir a posição do target//-------------------------------------------------------------//
    void LateUpdate()
    {
        targetPos = target.position;
        thisPos = transform.position;

        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;

        //angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }
    //-------------------------------------------------------------//Comportamento via Trigger//-------------------------------------------------------------//
    void OnTriggerEnter2D(Collider2D c)
    {
        //MOVIMENTO DO BOSS
        if (c.gameObject.tag == "Sensor")
        {
            movimento = true;
        }

        if(c.gameObject.name == "Sensor1")
        {
            StartCoroutine("Andar");
        }

        if (c.gameObject.name == "Sensor2")
        {

            StartCoroutine("Andar");
        }

        if (c.gameObject.name == "Sensor3")
        {
            StartCoroutine("Andar");
        }

        //Animãção 
        if(c.gameObject.name  == "Player")
        {
            animacao.SetBool("AchouJ", true);
        }

    }
    //-------------------------------------------------------------//contagem de vida//-------------------------------------------------------------//
    private void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.tag == "Projetil")
        {
            vida--;
        }

        if (vida == 0)
        {
            Destroy(gameObject);
        }
    }
    //-------------------------------------------------------------//Inverte a direção para que o BOSS esta andando//-------------------------------------------------------------//
    IEnumerator Andar()
    {
        yield return new WaitForSeconds(1.0f);
        Speed *= -1;
    }
}
