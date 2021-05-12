using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    [SerializeField]
    private GameObject hitEffectPrefab;

    [SerializeField]
    private int dano = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Transform t = transform;
        Destroy(gameObject);

        Instantiate(hitEffectPrefab, t.position, t.rotation);

        LifeManager lm = collision.gameObject.GetComponent<LifeManager>();
        if (lm != null) lm.AddLife(-dano);
    }
}
