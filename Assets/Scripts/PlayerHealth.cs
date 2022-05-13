using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public Text playerHealthText;

    private int _collisionHealthLoss = 10;
    private int _health;
    private int _startingHealth = 100;

    void Start()
    {
        _health = _startingHealth;
    }
        
    void OnTriggerEnter(Collider collider)
    {
        _health -= _collisionHealthLoss;
        playerHealthText.text = "Player Health: " + _health;
        Destroy(collider.gameObject);
    }
}
