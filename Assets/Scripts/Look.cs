using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public GameObject player;
    public GameObject bossMorto;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0.0f);
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.name == "BOSS")
        {
            transform.position = new Vector3(bossMorto.transform.position.x, bossMorto.transform.position.y, 0.0f);
        }
    }

}
