using System;
using System.Collections;
using UnityEngine;

public abstract class EnemyAI: MonoBehaviour {
    protected Enemy enemy { get; private set; }
    protected bool isDetectedPlayer;
    protected float distanceDetect;
    protected float timeMissDetect;

    public bool ShouldChase { get; private set; }
    public bool ShouldAttack { get; private set; }

    private float distance;

    protected virtual void Awake() {
        enemy = GetComponentInParent<Enemy>();
    }
    private void Start() {
        distanceDetect = enemy.EnemyPropertiesSO.BaseDistanceTrigger;
        timeMissDetect = Time.time;
        isDetectedPlayer = false;
    }

    protected virtual  void Update() {
        DetectPlayer();
        
    }

    protected virtual void FixedUpdate() {
        if (Time.time - timeMissDetect > 1) {
            isDetectedPlayer = false;
            distanceDetect = enemy.EnemyPropertiesSO.BaseDistanceTrigger;
        }
        if(isDetectedPlayer) {
            SetChasePlayer();
        }
        else
        {
            ShouldAttack = false;
            ShouldChase = false;
        }
    }


    public void SetChasePlayer() {
        ShouldChase = true;

        if (distance <= enemy.EnemyPropertiesSO.AttackDistance)
        {
            ShouldAttack = true;
            ShouldChase = false;
        }
        else
        {
            ShouldAttack = false;
            ShouldChase = true;
        }
    }

    public bool DetectPlayer() {
        // distance = Vector3.Distance(enemy.Player.transform.position, this.transform.position);
        // if(distance <= distanceDetect) {
        //     if (!isDetectedPlayer) {
        //         isDetectedPlayer = true;
        //         distanceDetect*= enemy.EnemyPropertiesSO.DetectModifierDistance;
        //     }
        //     timeMissDetect = Time.time;
        //     return true;
        // }
        // return false;
        return true;
    }
}