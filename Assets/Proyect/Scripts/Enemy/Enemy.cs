using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    public float life = 10;
    public float maxLife = 10;
    public float ki = 100;
    public float maxKi = 100;
    public float attack = 5;
    public float force = 3;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
}
