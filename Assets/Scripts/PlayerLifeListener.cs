using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeListener : MonoBehaviour
{
    [SerializeField] private Slider playerLife;

    private LifeManager lifeManager;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        lifeManager = GetComponent<LifeManager>();
        playerLife.maxValue = lifeManager.MaxLife;
        animator = GetComponent<Animator>();
    }

    void OnGUI() 
    {
        float t = Time.deltaTime / .5f;
        playerLife.value = Mathf.Lerp(playerLife.value, lifeManager.Life, t);
    }

    public void PlayerMorreu()
    {
        animator.SetBool("Morreu", true);
        GetComponent<PlayerController>().enabled = false;
    }
}
