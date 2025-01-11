using System;
using System.Collections;
using UnityEngine;

public abstract class EnemyAI: MonoBehaviour {
    protected Enemy enemy;
    protected bool isDetectedPlayer;
    protected float distanceDetect;
    protected float timeMissDetect;

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
            ChasePlayer();
        }
    }


    public void ChasePlayer() {
        Vector3 direction = (enemy.Player.transform.position - transform.position).normalized;
        enemy.Rigidbody.velocity = direction * enemy.EnemyPropertiesSO.BaseSpeed;
        this.transform.LookAt(enemy.Player.transform.position);
    }

    public bool DetectPlayer() {
        float distance = Vector3.Distance(enemy.Player.transform.position, this.transform.position);
        if(distance <= distanceDetect) {
            if (!isDetectedPlayer) {
                isDetectedPlayer = true;
                distanceDetect*=4;
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
        } else {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        }
        Gizmos.DrawWireSphere(transform.position, distanceDetect); 
    }
}