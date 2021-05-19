using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] public float velocidadeMaxima = 6f;

    [SerializeField] public float aceleracao = 6f;

    private float velocidade = 0f;

    private Rigidbody2D rb;

    private Transform alvo;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            alvo = col.transform;
            animator.SetBool("seguindo", true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            alvo = null;
            animator.SetBool("seguindo", false);
        }
    }

    void FixedUpdate()
    {
        if (alvo == null) return;

        velocidade = Mathf.Clamp(velocidade + aceleracao * Time.fixedDeltaTime, 0, velocidadeMaxima);

        Vector2 direcao = alvo.position - transform.position;
        rb.MovePosition(rb.position + direcao.normalized * velocidade * Time.fixedDeltaTime);

        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angulo;
    }
}
