using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public GameObject ProjetilPrefab;
    public GameObject arma;
    public GameObject Som;

    //inicio do teste
    public float offset;

    public Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    //fim do teste

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjetilPrefab, arma.transform.position, transform.rotation);
            Som.GetComponent<AudioSource>().Play();
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
}
