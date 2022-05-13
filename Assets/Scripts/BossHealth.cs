using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Text BossHealthText;

    private int _health;
    private int _startingHealth = 100;

    void Start()
    {
        _health = _startingHealth;
        BossHealthText.text = "Boss Health: " + _health;
    }
}
