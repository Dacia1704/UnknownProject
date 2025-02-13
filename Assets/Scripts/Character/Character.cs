using System;
using UnityEngine;

public abstract class Character: MonoBehaviour
{
    [HideInInspector]public Rigidbody Rigidbody;
    
    protected HealthBarUI healthBarUI;
    public Action<float> OnHealthDamaged;
    public Action<float> OnHealthHealed;
    public Action<float> OnMaxHealthChanged;
    
    
    [HideInInspector] public Damable Damable;

    protected virtual void Start()
    {
        Damable = GetComponentInChildren<Damable>();
    }
}