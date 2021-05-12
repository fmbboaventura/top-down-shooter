using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitoQuandoMorre : MonoBehaviour
{
    [SerializeField]
    private GameObject efeitoPrefab;

    public void DestruirEInstanciarEffeito()
    {
        Transform t = transform;
        Destroy(gameObject);

        GameObject efeito = Instantiate(efeitoPrefab, t.position, t.rotation);
        efeito.transform.localScale = t.localScale;
    }
}
