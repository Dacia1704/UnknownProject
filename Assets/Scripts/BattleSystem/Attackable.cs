using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Attackable: MonoBehaviour {
    public Stats AttackStats { get; private set; }

    public bool IsAttackSuccess { get; private set; }


    public void SetAttackStats(Stats stats)
    {
        this.AttackStats = stats;
    }


    protected virtual void OnTriggerEnter(Collider other) {
        Damable damable= other.gameObject.GetComponent<Damable>();
        if(damable != null) {
            // Debug.LogError(1 + " " + (damable.DamableLayers & (1 << this.gameObject.layer)));
            if ((damable.DamableLayers & (1 << this.gameObject.layer)) !=0)
            {
                // Debug.LogError(2);
                IsAttackSuccess = true;
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other) {
        Damable damable= other.gameObject.GetComponent<Damable>();
        if(damable != null) {
            if ((damable.DamableLayers & (1 << this.gameObject.layer)) !=0)
            {
                IsAttackSuccess = false;
            }
        }
    }
}