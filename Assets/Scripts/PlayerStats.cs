using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    public int life;
    
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Carregar()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null) return;

        LifeManager lifeManager = player.GetComponent<LifeManager>();
        lifeManager.Life = life;
    }
}
