using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public void SairDoJogo()
    {
        Application.Quit();
    }

    public void IniciarJogo()
    {
        LevelLoader.Instance.IniciarJogo();
    }
}
