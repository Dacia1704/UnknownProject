using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUI : UIBase
{
        [SerializeField] private Button playGameButton;
        [SerializeField] private Button settingButton;
        [SerializeField] private Button quitButton;
        
        private CanvasGroup canvasGroup;

        private void Awake()
        {
                canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
                playGameButton.onClick.AddListener(() =>
                {
                        if (MenuSceneUIManager.Instance.LoadingSceneUI == null)
                        {
                                Debug.Log("null");
                        }
                        MenuSceneUIManager.Instance.LoadingSceneUI.Enable();
                        MenuSceneUIManager.Instance.LoadingSceneUI.ShowLoadingScene();
                        SceneLoadManager.Instance.LoadSceneAsync(SceneLoadManager.Instance.FireSceneName);
                });
                
                settingButton.onClick.AddListener(() =>
                {
                        this.Disappear();
                        MenuSceneUIManager.Instance.SettingSceneUI.Appear();
                });
                
                quitButton.onClick.AddListener(() =>
                {
                        Debug.Log("Quit game");
                });
        }

        public void Appear()
        {
                canvasGroup.DOFade(1, 0.5f) 
                        .OnComplete(Enable);
        }

        public void Disappear()
        {
                canvasGroup.DOFade(0, 0.5f) 
                        .OnComplete(Disable);
        }
        
        
}