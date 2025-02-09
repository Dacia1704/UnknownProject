using System;
using System.Collections;
using UnityEngine;

public abstract class EnemyAI: MonoBehaviour {
    protected Enemy enemy;
    protected bool isDetectedPlayer;
    protected float distanceDetect;
    protected float timeMissDetect;

    [field: SerializeField]public bool ShouldChase { get; private set; }
    [field: SerializeField]public bool ShouldAttack { get; private set; }

    [SerializeField]private float distance;

    private void Awake() {
        enemy = GetComponent<Enemy>();
    }
    private void Start() {
        distanceDetect = enemy.EnemyPropertiesSO.BaseDistanceTrigger;
        timeMissDetect = Time.time;
        isDetectedPlayer = false;
    }

    private void Update() {
        DetectPlayer();
        
    }

    private void FixedUpdate() {
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
        distance = Vector3.Distance(enemy.Player.transform.position, this.transform.position);
        if(distance <= distanceDetect) {
            if (!isDetectedPlayer) {
                isDetectedPlayer = true;
                distanceDetect*= enemy.EnemyPropertiesSO.DetectModifierDistance;
            }
            timeMissDetect = Time.time;
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        if(!isDetectedPlayer)
        {
            Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
        } else if(ShouldChase) {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        } else if (ShouldAttack)
        {
            Gizmos.color = new Color(0f, 0f, 1f, 0.5f);
        }
        Gizmos.DrawWireSphere(transform.position, distanceDetect); 
    }
}