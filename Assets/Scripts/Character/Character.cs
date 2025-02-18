using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Character: MonoBehaviour
{
    [HideInInspector]public Rigidbody Rigidbody;

    protected HealthBarUI healthBarUI;
    public Action<float> OnHealthDamaged;
    public Action<float> OnHealthHealed;
    public Action<float> OnMaxHealthChanged;
    
    [field: SerializeField] protected Transform ToxicEffect { get; private set; }
    [field: SerializeField] protected Transform BurnEffect { get; private set; }
    [field: SerializeField] protected Transform FrozenEffect { get; private set; }
    [HideInInspector]public List<DebuffEffect> CurrentDebuffEffect { get; private set; }
    protected event Action<DebuffEffect> OnDebuffEffect;
    
    [HideInInspector]public Damable Damable;

    protected virtual void Awake()
    {
        Damable = GetComponentInChildren<Damable>();
        CurrentDebuffEffect = new List<DebuffEffect>();

        OnDebuffEffect += UpdateDebuffEffect;
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

    public void UpdateDebuffEffect(DebuffEffect debuffEffect)
    {
        if (CurrentDebuffEffect.Contains(debuffEffect)) return;
        CurrentDebuffEffect.Add(debuffEffect);
        if (debuffEffect ==DebuffEffect.Toxic)
        {
            ToxicEffect.gameObject.SetActive(true);
        }
        if (debuffEffect ==DebuffEffect.Burn)
        {
            BurnEffect.gameObject.SetActive(true);
        }
        if (debuffEffect ==DebuffEffect.Frozen)
        {
            FrozenEffect.gameObject.SetActive(true);
        }
    }

    public void InvokeOnDebuffEffect(DebuffEffect debuffEffect)
    {
        OnDebuffEffect?.Invoke(debuffEffect);
    }
    
    
}