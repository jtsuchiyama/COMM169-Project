using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Text BossHealthText;

    private int _health;
    private int _startingHealth = 100;
    private int _enragedHealth = 30;


    private int _collisionHealthLoss = 10;

    private Animator _animator;

    void Start()
    {
        _health = _startingHealth;
        BossHealthText.text = "Boss Health: " + _health;
        _animator = GetComponent<Animator>();
    }

    public void ReduceHealth()
    {
        _health -= _collisionHealthLoss;
        BossHealthText.text = "Boss Health: " + _health;

        if (_health == _enragedHealth)
            _animator.SetBool("isEnraged", true);

        if (_health == 0)
            _animator.SetBool("isDead", true);
    }
}
