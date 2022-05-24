using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public Text PlayerHealthText;

    private int _collisionHealthLoss = 10;
    private int _health;
    private int _startingHealth = 100;

    void Start()
    {
        _health = _startingHealth;
        PlayerHealthText.text = "Player Health: " + _health;
    }
        
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.name == "Projectile(Clone)")
        {
            ReduceHealth();
            Destroy(collider.gameObject);
        }
        
    }

    public void ReduceHealth()
    {
        _health -= _collisionHealthLoss;
        PlayerHealthText.text = "Player Health: " + _health;
    }
}
