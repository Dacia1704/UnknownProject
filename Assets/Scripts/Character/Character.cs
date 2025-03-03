using System;
using System.Collections;
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
    
    [field: SerializeField] protected Transform ToxicEffect { get; private set; } // get dam until die 1%hp per hit
    [field: SerializeField] protected Transform BurnEffect { get; private set; } // get dam in 15s 4%hp per hit
    [field: SerializeField] protected Transform FrozenEffect { get; private set; } // slow 70% in 3s
    [HideInInspector]public List<DebuffEffect> CurrentDebuffEffect { get; private set; }
    protected event Action<DebuffEffect> OnDebuffEffect;

    public float SpeedModifierbyEffect { get; private set; }
    
    [HideInInspector]public Damable Damable;

    protected virtual void Awake()
    {
        Damable = GetComponentInChildren<Damable>();
        CurrentDebuffEffect = new List<DebuffEffect>();

        OnDebuffEffect += UpdateDebuffEffect;
        SpeedModifierbyEffect = 1f;
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
        UpdateDebuffDamage(debuffEffect);
    }

    public void UpdateDebuffDamage(DebuffEffect debuffEffect)
    {
        if (debuffEffect == DebuffEffect.Frozen)
        {
            StartCoroutine(FrozenEffectCoroutine());
            return;
        }
        if (debuffEffect == DebuffEffect.Burn)
        {
            StartCoroutine(BurnEffectCoroutine());
            return;
        }
        if (debuffEffect == DebuffEffect.Toxic)
        {
            StartCoroutine(ToxicEffectCoroutine());
        }
    }

    protected IEnumerator FrozenEffectCoroutine()
    {
        SpeedModifierbyEffect = 0.3f;
        yield return new WaitForSeconds(3);
        SpeedModifierbyEffect = 1f;
        FrozenEffect.gameObject.SetActive(false);
    }

    protected virtual IEnumerator BurnEffectCoroutine()
    {
        yield return null;
    }

    protected virtual IEnumerator ToxicEffectCoroutine()
    {
        yield return null;
    }

    public void InvokeOnDebuffEffect(DebuffEffect debuffEffect)
    {
        OnDebuffEffect?.Invoke(debuffEffect);
    }
    
    
}