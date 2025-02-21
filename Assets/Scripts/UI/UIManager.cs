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
        [HideInInspector] public PlayerHealthBarUI PlayerHealthBarUI;
        public AudioSource UIAudioSource { get; private set; }
        

        private void Awake()
        {
                Instance = this;
                EquipmentMenuUI = GetComponentInChildren<EquipmentMenuUI>();
                PlayerHealthBarUI = GetComponentInChildren<PlayerHealthBarUI>();
                UIAudioSource = GetComponent<AudioSource>();
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
                                EquipmentMenuUI.UpdateInventoryUI(EquipmentManager.instance.InventoryItems);
                        }
                });
        }
        public bool IsPointerOverUIElement()
        {
                return EventSystem.current.IsPointerOverGameObject();
        }


}