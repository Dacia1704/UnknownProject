using UnityEngine;

public abstract class CollisionManager : MonoBehaviour {
    protected virtual bool CheckCollisionWithBox(Vector3 position,Vector3 size,Vector3 direction,float maxDistance,LayerMask layer) {
        return Physics.BoxCast(position, size * 0.5f, direction, Quaternion.identity,maxDistance, layer);
    }

    protected virtual void OnCollisionEnter(Collision other) {
        
    }

    protected virtual void OnCollisionStay(Collision other) {
        
    }

    protected virtual void OnCollisionExit(Collision other) {
        
    }


    
}