using System;
using UnityEngine;

public abstract class Character: MonoBehaviour
{
    [HideInInspector]public Rigidbody Rigidbody;
    
    protected HealthBarUI healthBarUI;
    public Action<float,float> OnHealthChanged;
    
    
    [HideInInspector] public Damable Damable;

    protected virtual void Start()
    {
        healthBarUI = GetComponentInChildren<HealthBarUI>();
        Damable = GetComponentInChildren<Damable>();
    }
}