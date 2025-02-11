using UnityEngine;

public class PlayerBodyCollisionManager: CollisionManager {

    [field: Header("Layer Mask")]
    [SerializeField]protected LayerMask groundLayerMask;
    
    [field: Header("Check Value")]
    public bool isGround { get; private set; }

    [field: Header("CheckProps")]
    [SerializeField] protected Transform groundCheckPosition;
    [SerializeField] protected Vector3 groundCheckSize;
    [SerializeField] protected float distance;
    protected void Update() {
        this.transform.localPosition = Vector3.zero;
        isGround = CheckCollisionWithBox(groundCheckPosition.transform.position, groundCheckSize,Vector3.down,distance, groundLayerMask);        
    }

    private void OnDrawGizmos() {
        Gizmos.color = isGround? Color.green: Color.red;
        Gizmos.DrawRay(groundCheckPosition.transform.position, Vector2.down * distance);
        Gizmos.DrawCube(groundCheckPosition.transform.position, groundCheckSize); 
    }
}