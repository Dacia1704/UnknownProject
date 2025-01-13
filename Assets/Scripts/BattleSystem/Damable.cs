using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Damable: MonoBehaviour {
    public int MaxHealth { get; set; }
    public List<string> TagCanDealDamList { get; private set; }

    public int IsGetAttack { get; private set; }

    protected virtual void OnTriggerEnter(Collider other) {
        Attackable attackable= other.gameObject.GetComponent<Attackable>();
        if (attackable!=null) {
            if (TagCanDealDamList.Contains(other.transform.tag)) {
                IsGetAttack = attackable.Attack;
            }
        }
    }

    protected virtual void OnTriggerStay(Collider other) {
        
    }

    protected virtual void OnTriggerExit(Collider other) {
        Attackable attackable= other.gameObject.GetComponent<Attackable>();
        if (attackable!=null) {
            if (TagCanDealDamList.Contains(other.transform.tag)) {
                IsGetAttack = 0;
            }
        }
    }
    public void GetDamage(ref int health, int damage) {
        health = Mathf.Clamp(health - damage, 0, MaxHealth);
    }

    public void SetTagCanDealDamList(List<string> tagList) {
        this.TagCanDealDamList = tagList;
    }
}