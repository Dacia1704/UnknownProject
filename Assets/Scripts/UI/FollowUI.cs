using System;
using UnityEngine;
using UnityEngine.UI;

public class FollowUI : MonoBehaviour
{
      [SerializeField] private Transform lookAt;
      [SerializeField] private Vector3 offset;

      private Image imageBG; 

      private void Start()
      {
            
            imageBG = GetComponent<Image>();
      }

      private void Update()
      {
            var canvas = imageBG.canvas;

            Vector3 pos = lookAt.position + offset;
            pos.z = canvas.planeDistance;
            imageBG.transform.localPosition = canvas.worldCamera.ScreenToWorldPoint(pos);
      }
}