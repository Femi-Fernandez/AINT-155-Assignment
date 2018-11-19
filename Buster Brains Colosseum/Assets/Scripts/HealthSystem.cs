﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable]
public class OnDamagedEvent : UnityEvent<int> { }

public class HealthSystem : MonoBehaviour {

    public int health = 10;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;

    public void TakeDamage(int Damage)
    {
        health -= Damage;

        onDamaged.Invoke(health);

        if (health < 1)
        {
            onDie.Invoke();
            print("test");
        }
    }
}
