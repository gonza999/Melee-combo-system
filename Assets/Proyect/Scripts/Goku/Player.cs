using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public float life = 100;
    public float maxLife = 100;
    public float ki = 100;
    public float maxKi = 100;
    public float damage = 1;
    public float speed = 2;
    public float forceJump = 5;
    public float force = 1;
    public float forceCharge = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
