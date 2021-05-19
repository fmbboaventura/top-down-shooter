using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidade = 8;

    public float forcaDaBala = 20;

    private Rigidbody2D rb;

    private Vector2 movimento;

    private Vector2 posMouse;

    public Transform arma;

    public GameObject balaPrefab;

    public AudioSource audioSource;

    // Start é chamado umavez antes do primeiro update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Registra a posição que o usuário deseja se mover usando wasd ou as setas
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        // Captura a posição do cursor do mouse e converte de cordenadas da tela para coordenadas
        // do mundo do jogo
        posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            // Instancia a bala
            GameObject bala = Instantiate(balaPrefab, arma.position, arma.rotation);

            // Aplica um inpulso na bala, na direção do vetor 'up' da arma e com o módulo igual a forcaDaBala
            bala.GetComponent<Rigidbody2D>().AddForce(arma.up * forcaDaBala, ForceMode2D.Impulse);

            // Dá play no som da arma
            audioSource.Play();
        }
    }

    // FixedUpdate é chamado em um intervalo de tempo fixo, e portanto, não é afedado por variações de frame rate
    // É o método sugerido para fazer manipulações na física do jogo.
    void FixedUpdate()
    {
        // Move o jogador para uma nova posição definida por:
        // posição atual + a direção do movimento definida pelo input 
        // * a velocidade desejada * o tempo entre a chamada atual e a ultima chamada 
        // do método FixedUpdate
        rb.MovePosition(rb.position + movimento.normalized * velocidade * Time.fixedDeltaTime);

        // Traça um vetor entre a posição do jogador e a posição do mouse
        Vector2 direcao = posMouse - rb.position;
        
        // Calcula o angulo entre esse vetor e o eixo X, converte em graus e
        // desloca em 90 graus
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angulo;
    }
}
