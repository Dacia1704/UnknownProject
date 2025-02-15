using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BodyColliderManager: MonoBehaviour
{
        [field: Header("Layer Mask")]
        [SerializeField]protected LayerMask groundLayerMask;
        public Collider BodyCollision { get; private set; }
        
        public bool IsGrounded { get; private set; }
        
        [field: Header("CheckProps")]
        [SerializeField] protected Transform groundCheckPosition;
        [SerializeField] protected Vector3 groundCheckSize;
        [SerializeField] protected float distance;

        private void Awake()
        {
                BodyCollision = GetComponent<Collider>();
        }
        
        protected void Update() {
                IsGrounded = CheckCollisionWithBox(groundCheckPosition.transform.position, groundCheckSize,Vector3.down,distance, groundLayerMask);        
        }

        private void OnDrawGizmos() {
                Gizmos.color = IsGrounded? Color.green: Color.red;
                Gizmos.DrawRay(groundCheckPosition.transform.position, Vector2.down * distance);
                Gizmos.DrawCube(groundCheckPosition.transform.position, groundCheckSize); 
        }
        
        protected virtual bool CheckCollisionWithBox(Vector3 position,Vector3 size,Vector3 direction,float maxDistance,LayerMask layer) {
                return Physics.BoxCast(position, size * 0.5f, direction, Quaternion.identity,maxDistance, layer);
        }
}