using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject passos;

    public Text ContagemV;
    public int Vida;

    public Text ContagemT;
    public int Tesouro;

    public float Velocidade;

    Animator animacao;
    SpriteRenderer sprite;

    bool FinalFase;
    bool morte;
    //---------------------------------------//Definições//---------------------------------------//
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
        FinalFase = false;
        morte = false;
    }

    //---------------------------------------//Movimentação e Animação//---------------------------------------//
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal") * Velocidade * Time.deltaTime;
        float Y = Input.GetAxisRaw("Vertical") * Velocidade * Time.deltaTime;

        transform.Translate(X, Y, 0.0f);

        if (Input.GetKey("down"))
        {
            animacao.SetBool("Andando", true);
        }

        else if(Input.GetKey("up"))
        {
            animacao.SetBool("AndarCima", true);
        }

        else if (Input.GetKey("left"))
        {
            animacao.SetBool("AndarEsquerda", true);
        }

        else if (Input.GetKey("right"))
        {
            animacao.SetBool("AndarDireita", true);
        }
        else
        {
            animacao.SetBool("AndarDireita", false);
            animacao.SetBool("Andando", false);
            animacao.SetBool("AndarCima", false);
            animacao.SetBool("AndarEsquerda", false);
        }

        //morte
        if(Vida == 0)
        {
            morte = true;
            sprite.enabled = false;
            transform.Translate(Y, X, 0.0f);
        }

        if(morte == true)
        {
            StartCoroutine(Morte());
        }
    }
    //---------------------------------------//Contagem de Vida e de Tesouro//---------------------------------------//
    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.name == "Inimigo")
        {
            Vida--;

            ContagemV.text = Vida.ToString();
        }

        else if(c.gameObject.name == "Projetil")
        {
            Vida--;

            ContagemV.text = Vida.ToString();
        }

        if (c.gameObject.tag == "Tesouro")
        {
            Destroy(c.gameObject);

            Tesouro++;
          
            if (Tesouro == 3)
            {
                FinalFase = true;
            }

            ContagemT.text = Tesouro.ToString();
        }
         //ajustar o ocdig aqui 
         
    }
    //---------------------------------------//Definir quando acabar o jogo quando o jogador atingir o final//---------------------------------------//
    private void OnTriggerEnter2D(Collider2D c)
    {
        
        if (c.gameObject.name == "final" && FinalFase == true)
        {
            FinalFase = false;
            StartCoroutine(Final());
            
            
        }
    }
    //---------------------------------------//troca a cena para a tela de final de jogo (Vitória)//---------------------------------------//
    IEnumerator Final()
    {
        print("sfadna");

        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Vitoria");
    }

    IEnumerator Morte()
    {
        print("to doido");

        
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Final");


    }

}
