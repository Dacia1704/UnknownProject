using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
        public static UIManager Instance { get; private set; }
        [SerializeField] protected Button randomDropButton;
        [SerializeField] protected Button swordButton;
        [SerializeField] protected Button staffButton;
        [SerializeField] protected Button bowButton;
        
        [Header("EquipmentMenu")]
        [SerializeField] protected Button equipmentButton;
        [HideInInspector] public EquipmentMenuUI EquipmentMenuUI;
        [HideInInspector] public PlayerHealthBarUI PlayerHealthBarUI;

        public event Action OnSwordButtonClicked;
        public event Action OnStaffButtonClicked;
        public event Action OnBowButtonClicked;
        

        private void Awake()
        {
                Instance = this;
                EquipmentMenuUI = GetComponentInChildren<EquipmentMenuUI>();
                PlayerHealthBarUI = GetComponentInChildren<PlayerHealthBarUI>();
        }

        private void Start()
        {
                randomDropButton.onClick.AddListener(() => EquipmentManager.instance.RandomDrop());
                
                swordButton.onClick.AddListener(() => OnSwordButtonClicked?.Invoke());
                staffButton.onClick.AddListener(() => OnStaffButtonClicked?.Invoke());
                bowButton.onClick.AddListener(() => OnBowButtonClicked?.Invoke());
                equipmentButton.onClick.AddListener(() =>
                {
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