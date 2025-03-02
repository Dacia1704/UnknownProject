using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingSceneUI : UIBase
{
        private Vector3 originalPos;

        [SerializeField]private Slider globalSlider;
        [SerializeField]private Slider bmgSlider;
        [SerializeField]private Slider sfxSlider;

        [SerializeField] private Button BackButton;


        public event Action<float, float, float> OnVolumnChanged;

        private void Awake()
        {
                SaveLoadManager.Instance.OnGameDataLoaded += LoadAudioSlider;
                OnVolumnChanged += SaveLoadManager.Instance.LoadDataVolumnToSave;
                OnVolumnChanged += AudioManager.Instance.LoadVolumnData;
        }

        private void Start()
        {
                originalPos = base.transform.position;
                
                
                
                BackButton.onClick.AddListener(() =>
                {
                        this.Disappear();
                        MenuSceneUIManager.Instance.MainSceneUI.Appear();
                        AudioManager.Instance.PlayButtonAudio(MenuSceneUIManager.Instance.AudioSource);
                });
                
                
                globalSlider.onValueChanged.AddListener((value) =>
                {
                        AudioManager.Instance.SetMasterVolumn(value);
                        OnVolumnChanged?.Invoke(value, globalSlider.value, bmgSlider.value);
                });
                bmgSlider.onValueChanged.AddListener((value) =>
                {
                        AudioManager.Instance.SetBGMVolumn(value);
                        OnVolumnChanged?.Invoke(value, bmgSlider.value, sfxSlider.value);
                });
                sfxSlider.onValueChanged.AddListener((value) =>
                {
                        AudioManager.Instance.SetSFXVolumn(value);
                        OnVolumnChanged?.Invoke(value, sfxSlider.value, globalSlider.value);
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

        private void LoadAudioSlider(GameData gameData)
        {
                globalSlider.value = gameData.GlobalAudioVolume;
                bmgSlider.value = gameData.BMGAudioVolume;
                sfxSlider.value = gameData.SFXAudioVolume;
        }
}