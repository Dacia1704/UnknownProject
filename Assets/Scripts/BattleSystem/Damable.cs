using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Damable: MonoBehaviour {
    public Stats DamableStats { get; set; }
    
    [field: SerializeField] public LayerMask DamableLayers { get; private set; }

    public int IsGetAttack { get; private set; }

    protected virtual void OnTriggerEnter(Collider other) {
        Attackable attackable= other.gameObject.GetComponent<Attackable>();
        if (attackable!=null) {
            // Debug.LogError(1 +" " +(DamableLayers & (1 << other.gameObject.layer)));
            if ((DamableLayers & (1 << other.gameObject.layer)) !=0)
            {
                // Debug.LogError(2);
                IsGetAttack = attackable.AttackStats.Attack;
            }
        }
    }
    protected virtual void OnTriggerExit(Collider other) {
        Attackable attackable= other.gameObject.GetComponent<Attackable>();
        if (attackable!=null) {
            if ( (DamableLayers & (1 << other.gameObject.layer)) !=0 )
            {
                IsGetAttack = 0;
            }
        }
    }
    public void GetDamage(ref int health, int damage) {
        health = Mathf.Clamp(health - damage, 0, DamableStats.Health);
    }

    public void ResetIsGetAttack()
    {
        IsGetAttack = 0;
    }
    public void SetDamableLayer(LayerMask layers)
    {
        this.DamableLayers = layers;
    }
}