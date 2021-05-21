using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoColisao : MonoBehaviour
{
    [SerializeField] private string tagDoAlvo;

    [SerializeField] private int dano = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagDoAlvo) {
            collision.gameObject.GetComponent<LifeManager>().CausarDano(dano);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagDoAlvo) {
            collision.gameObject.GetComponent<LifeManager>().CausarDano(dano);
        }
    }
}
