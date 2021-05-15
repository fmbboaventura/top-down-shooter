using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private float velocidade = 9f;

    private Rigidbody2D rb;

    [SerializeField] private Transform alvo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            alvo = col.transform;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            alvo = null;
        }
    }

    void FixedUpdate()
    {
        if (alvo == null) return;

        Vector2 direcao = alvo.position - transform.position;
        rb.MovePosition(rb.position + direcao.normalized * velocidade * Time.fixedDeltaTime);

        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angulo;
    }
}
