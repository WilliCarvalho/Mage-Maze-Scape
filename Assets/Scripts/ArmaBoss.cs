using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaBoss : MonoBehaviour
{
    public GameObject AtaquePrefab;
    public GameObject arma;
    public GameObject som;

    private bool achou;

    //inicio do teste
    public float offset;

    public Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    //fim do teste

    private void Start()
    {
        achou = false;
    }

    private void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D c)
    {
        //ATIRAR NO JOGADOR
        if (c.gameObject.tag == "Player")
        {
            achou = true;

            print(achou);
        }

        if (achou == true)
        {
            StartCoroutine(Atirar());
        }
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if(c.gameObject.tag == "Player")
        {
            achou = false;
            StartCoroutine(Atirar());
            print("Foi embora");
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

    IEnumerator Atirar()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(AtaquePrefab, arma.transform.position, transform.rotation);
        som.GetComponent<AudioSource>().Play();
        achou = false;
    }
}
