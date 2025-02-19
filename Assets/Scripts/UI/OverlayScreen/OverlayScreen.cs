using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OverlayScreen: UIBase
{
        public static OverlayScreen Instance;
        [field: SerializeField] private Color healColor;
        [field: SerializeField] private Color lowHealthColor;

        private Image image;
        private CanvasGroup canvasGroup;

        private void Awake()
        {
                Instance = this;
                image = GetComponent<Image>();
                canvasGroup = GetComponent<CanvasGroup>();
                
                transform.SetAsLastSibling();
        }


        public void ShowHealOverlayScreenByTime(float duration)
        {
                StartCoroutine(ShowHealOverlayScreenByTimeCoroutine(duration));
        }

        private IEnumerator ShowHealOverlayScreenByTimeCoroutine(float duration)
        {
                ShowHealOverlayScreen();
                yield return new WaitForSeconds(duration);
                HideOverlayScreen();
        }
        
        public void ShowLowHealthOverlayScreenByTime(float duration)
        {
                StartCoroutine(ShowLowHealthOverlayScreenByTimeCoroutine(duration));
        }

        private IEnumerator ShowLowHealthOverlayScreenByTimeCoroutine(float duration)
        {
                ShowLowHealthOverlayScreen();
                yield return new WaitForSeconds(duration);
                HideOverlayScreen();
        }
        
        
        

        private void ShowHealOverlayScreen()
        {
                image.color = healColor;
                canvasGroup.alpha = 0.01f;
        }
        
        private void ShowLowHealthOverlayScreen()
        {
                image.color = lowHealthColor;
                canvasGroup.alpha = 0.01f;
        }

        private void HideOverlayScreen()
        {
                canvasGroup.alpha = 0f;
        }
}