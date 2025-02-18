using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Attackable: MonoBehaviour {
    public Stats AttackStats { get; private set; }

    public bool IsAttackSuccess { get; set; }
    
    public bool IsMapCollider { get; set; }

    public void SetAttackStats(Stats stats)
    {
        this.AttackStats = stats;
    }


    protected virtual void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("MapCollider"))
        {
            IsMapCollider = true;
        }
        
        Damable damable= other.gameObject.GetComponent<Damable>();
        if(damable != null) {
            if ((damable.DamableLayers & (1 << this.gameObject.layer)) !=0)
            {
                IsAttackSuccess = true;
            }
        }
    }
}