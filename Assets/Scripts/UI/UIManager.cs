using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
        public static UIManager Instance { get; private set; }
        
        
        [Header("EquipmentMenu")]
        [SerializeField] protected Button equipmentButton;
        [HideInInspector] public EquipmentMenuUI EquipmentMenuUI;
        public PlayerHealthBarUI PlayerHealthBarUI;
        public AudioSource UIAudioSource { get; private set; }
        

        private void Awake()
        {
                Instance = this;
                EquipmentMenuUI = GetComponentInChildren<EquipmentMenuUI>();
                UIAudioSource = GetComponent<AudioSource>();
                PlayerHealthBarUI = GetComponentInChildren<PlayerHealthBarUI>();
        }

        private void Start()
        {
                equipmentButton.onClick.AddListener(() =>
                {
                        AudioManager.Instance.PlayButtonAudio(UIAudioSource);
                        if (EquipmentMenuUI.gameObject.activeSelf) EquipmentMenuUI.Disable();
                        else
                        {
                                EquipmentMenuUI.Enable();
                                EquipmentMenuUI.UpdateInventoryUI(EquipmentManager.Instance.InventoryItems);
                        }
                });
        }
        public bool IsPointerOverUIElement()
        {
                return EventSystem.current.IsPointerOverGameObject();
        }


}