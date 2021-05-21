using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoFlash : MonoBehaviour
{
    [SerializeField] private Color corDoFlash = Color.red;

    [SerializeField] private float tempoDoFlash = 0.1f;

    private float timer;

    private Color corDefault;

    private Color corAnterior;

    private Color proximaCor;

    private LifeManager lifeManager;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lifeManager = GetComponent<LifeManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        corDefault = spriteRenderer.color;
        proximaCor = corDoFlash;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeManager.Invencivel) {
            timer += Time.deltaTime;

            if (timer > tempoDoFlash) {
                timer = 0;
                corAnterior = spriteRenderer.color;
                spriteRenderer.color = proximaCor;
                proximaCor = corAnterior;
            }
        } else {
            proximaCor = corDoFlash;
            spriteRenderer.color = corDefault;
        }
    }
}
