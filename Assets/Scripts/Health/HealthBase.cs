using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnkill = false;

    public float delayTokill = .2f;

    private int _currenLife;
    private bool _isDead = false; 

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _isDead = false;
        _currenLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;    
        _currenLife-= damage;
        if (_currenLife <= 0) 
        {
            kill();
        }
    }
    private void kill()
    {
        _isDead=true;
       if (destroyOnkill) 
       {
          Destroy(gameObject, delayTokill);
       }
    
    
    }



}
