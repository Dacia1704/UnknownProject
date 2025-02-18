using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]
public class Damable: MonoBehaviour {
    public Stats DamableStats { get; set; }
    
    [field: SerializeField] public LayerMask DamableLayers { get; private set; }
    public Stats AttackableStats { get; private set; }

    private void Awake()
    {
        ResetAttackableStats();
    }

    protected virtual void OnTriggerEnter(Collider other) {
        Attackable attackable= other.gameObject.GetComponent<Attackable>();
        if (attackable!=null) {
            if ((DamableLayers & (1 << other.gameObject.layer)) !=0)
            {
                AttackableStats = attackable.AttackStats.Clone();
            }
        }
    }
    protected virtual void OnTriggerExit(Collider other) {
        Attackable attackable= other.gameObject.GetComponent<Attackable>();
        if (attackable!=null) {
            if ( (DamableLayers & (1 << other.gameObject.layer)) !=0 )
            {
                ResetAttackableStats();
            }
        }
    }
    public void GetDamage(ref int health, int damage) {
        health = Mathf.Clamp(health - damage, 0, DamableStats.Health);
    }
    
    public void ResetAttackableStats()
    {
        AttackableStats = new Stats();
    }
    public void SetDamableLayer(LayerMask layers)
    {
        this.DamableLayers = layers;
    }

    public DebuffEffect RandomDebuffEffect()
    {
        if (AttackableStats?.CanDealDebuffEffects.Count == 0) return DebuffEffect.None;
        float successRate = AttackableStats.Accuracy - DamableStats.Resistance;
        successRate = Math.Clamp(successRate, 0f, 100f);
        successRate = 100f;
        float roll = Random.Range(0f, 100f);
        if (roll < successRate)
        {
            int randomDebuff = Random.Range(0,AttackableStats.CanDealDebuffEffects.Count-1);
            return AttackableStats.CanDealDebuffEffects[randomDebuff];
        }
        return DebuffEffect.None;
    }
}