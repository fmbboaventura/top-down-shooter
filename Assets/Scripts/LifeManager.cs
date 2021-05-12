using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeManager : MonoBehaviour
{
    private int life = 0;

    [SerializeField]
    private int maxLife = 100;

    [SerializeField]
    private UnityEvent onDeath;

    // Start is called before the first frame update
    void Start()
    {
        AddLife(maxLife);
    }

    public void AddLife(int val)
    {
        life = Mathf.Clamp(life + val, 0, maxLife);

        if (life == 0) 
        {
            onDeath.Invoke();
        }
    }
}
