using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{


    public void Reiniciar()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Menuprincipal()
    {
        SceneManager.LoadScene("Inicio");
    }


}

