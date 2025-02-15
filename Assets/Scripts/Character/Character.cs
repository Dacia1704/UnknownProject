using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Character: MonoBehaviour
{
    [HideInInspector]public Rigidbody Rigidbody;

    protected HealthBarUI healthBarUI;
    public Action<float> OnHealthDamaged;
    public Action<float> OnHealthHealed;
    public Action<float> OnMaxHealthChanged;
    
    
    [HideInInspector]public Damable Damable;

    protected virtual void Awake()
    {
        Damable = GetComponentInChildren<Damable>();
    }

    public virtual void DeathStart()
    {
        
    }

    public virtual void DeathEnd()
    {
        
    }

    public virtual void ResetCharacter()
    {
        
    }
}