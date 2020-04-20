using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olhando : MonoBehaviour
{
    private float velocidade = 10;

    void Update()
    {
        Vector2 posicaoMouse = Input.mousePosition;
        posicaoMouse = Camera.main.ScreenToWorldPoint(posicaoMouse);

        posicaoMouse = new Vector2(posicaoMouse.x, posicaoMouse.y + 1.0f);
        transform.position = Vector2.Lerp(transform.position, posicaoMouse, velocidade * Time.deltaTime);
    }
}
