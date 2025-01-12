using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Attackable: MonoBehaviour {
    public int Attack { get; private set; }

    public bool IsAttackSuccess { get; private set; }

    protected Collider attackCollider;

    protected virtual void Start() {
        attackCollider = GetComponent<Collider>();
    }

    protected virtual void OnTriggerEnter(Collider other) {
        Damable damable= other.gameObject.GetComponent<Damable>();
        if(damable != null) {
            if (damable.TagCanDealDamList.Contains(transform.tag)) {
                IsAttackSuccess = true;
            }
            
        }
    }

    protected virtual void OnTriggerStay(Collider other) {
        
    }

    protected virtual void OnTriggerExit(Collider other) {
        Damable damable= other.gameObject.GetComponent<Damable>();
        if(damable != null) {
            if (damable.TagCanDealDamList.Contains(transform.tag)) {
                IsAttackSuccess = false;
            }
        }
    }
}