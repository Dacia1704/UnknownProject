using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSceneUI : UIBase
{
        public Slider LoadingSlider;
        
        private CanvasGroup canvasGroup;

        [SerializeField] private float loadSpeed;

        private void Awake()
        {
                canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
                canvasGroup.DOFade(0, 0f);
                LoadingSlider.gameObject.SetActive(false);
                Disable();
        }


        private void FixedUpdate()
        {
                FakeUpdateLoading(SceneLoadManager.Instance.ProgressValue);
        }

        public void ShowLoadingScene()
        {
                canvasGroup.DOFade(1, 0.5f)
                        .OnComplete( () => LoadingSlider.gameObject.SetActive(true));
        }

        private void FakeUpdateLoading(float progress)
        {
                progress = Mathf.Clamp01(progress);
                LoadingSlider.value = Mathf.MoveTowards(LoadingSlider.value, progress, loadSpeed * Time.fixedDeltaTime);
                if (LoadingSlider.value >=0.99f )
                {
                        SceneLoadManager.Instance.LoadSceneImmediately(SceneLoadManager.Instance.FireSceneName); 
                }
                
                
        }
        
}