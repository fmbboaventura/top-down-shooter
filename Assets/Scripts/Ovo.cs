using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovo : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private float tempoParaChocar = 3f;

    [SerializeField] private GameObject inimigo;

    private float timer = 0;

    private bool chocando = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chocando) {
            timer += Time.deltaTime;

            if (timer >= tempoParaChocar) {
                Instantiate(inimigo, transform.position, transform.rotation);
                GetComponent<EfeitoQuandoMorre>().DestruirEInstanciarEffeito();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            chocando = true;
            animator.SetBool("chocando", chocando);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") {
            chocando = false;
            animator.SetBool("chocando", chocando);
        }
    }
}
