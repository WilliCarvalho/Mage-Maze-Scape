using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public Transform playerSprite;

    public float offset;

    public Transform target;
    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;

    void Start()
    {
        
    }

    void Update()
    {
        playerSprite.position = transform.position;
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
