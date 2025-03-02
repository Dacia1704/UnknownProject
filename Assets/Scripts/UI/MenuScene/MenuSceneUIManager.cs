using System;
using UnityEngine;

public class MenuSceneUIManager : MonoBehaviour
{
        public static MenuSceneUIManager Instance;

        public MainSceneUI MainSceneUI { get; private set; }
        public SettingSceneUI SettingSceneUI { get; private set; }
        public LoadingSceneUI LoadingSceneUI { get; private set; }
        
        public AudioSource AudioSource { get; private set; }
        private void Awake()
        {
                Instance = this;
                MainSceneUI = GetComponentInChildren<MainSceneUI>();
                SettingSceneUI = GetComponentInChildren<SettingSceneUI>();
                LoadingSceneUI = GetComponentInChildren<LoadingSceneUI>();
                AudioSource = GetComponent<AudioSource>();
        }
        
        
}