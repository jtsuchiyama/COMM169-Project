using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _health = 100;

    void ReduceHealth(int healthSubtract)
    {
        _health -= healthSubtract;
    }
}
