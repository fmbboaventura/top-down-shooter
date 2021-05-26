using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string proximoLevel;

    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player") return;
        PlayerStats.Instance.life = collider.gameObject.GetComponent<LifeManager>().Life;
        LevelLoader.Instance.CarregarLevel(proximoLevel);
    }
}
