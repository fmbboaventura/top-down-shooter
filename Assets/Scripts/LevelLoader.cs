using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader Instance;
    
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

    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MenuPrincipal();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "MenuPrincipal") {
            PlayerStats.Instance.Carregar();
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    IEnumerator CarregarCena(string cena)
    {
        animator.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(cena);

        animator.SetTrigger("FadeIn");
    }

    public void IniciarJogo()
    {
        StartCoroutine(CarregarCena("Level1"));
    }

    public void MenuPrincipal()
    {
        StartCoroutine(CarregarCena("MenuPrincipal"));
    }

    public void CarregarLevel(string nomeDoLevel)
    {
        StartCoroutine(CarregarCena(nomeDoLevel));
    }
}
