using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingSceneUI : UIBase
{
        private Vector3 originalPos;

        [SerializeField] private Button BackButton; 


        private void Start()
        {
                originalPos = base.transform.position;
                
                BackButton.onClick.AddListener(() =>
                {
                        this.Disappear();
                        MenuSceneUIManager.Instance.MainSceneUI.Appear();
                });
        }


        public void Disappear()
        {
                transform.DOMove(originalPos, 0.5f)
                        .SetEase(Ease.OutQuad);
        }

        public void Appear()
        {
                transform.DOMove(MenuSceneUIManager.Instance.transform.position, 0.5f)
                        .SetEase(Ease.OutQuad);
        }
}