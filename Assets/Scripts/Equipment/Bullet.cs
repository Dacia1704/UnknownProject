using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
        public Attackable Attackable {get; private set; }
        

        private void Awake()
        {
                this.Attackable = GetComponentInChildren<Attackable>();
        }
}