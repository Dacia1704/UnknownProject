using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
        public static UIManager Instance { get; private set; }
        [SerializeField] protected Button swordButton;
        [SerializeField] protected Button staffButton;
        [SerializeField] protected Button bowButton;
        
        [Header("EquipmentMenu")]
        [SerializeField] protected Button equipmentButton;
        public EquipmentMenuUI EquipmentMenuUI;

        public event Action OnSwordButtonClicked;
        public event Action OnStaffButtonClicked;
        public event Action OnBowButtonClicked;
        

        private void Awake()
        {
                Instance = this;
                EquipmentMenuUI = GetComponentInChildren<EquipmentMenuUI>();
        }

        private void Start()
        {
                
                swordButton.onClick.AddListener(() => OnSwordButtonClicked?.Invoke());
                staffButton.onClick.AddListener(() => OnStaffButtonClicked?.Invoke());
                bowButton.onClick.AddListener(() => OnBowButtonClicked?.Invoke());
                equipmentButton.onClick.AddListener(() =>
                {
                        if (EquipmentMenuUI.gameObject.activeSelf) EquipmentMenuUI.Hide();
                        else EquipmentMenuUI.Show();
                });
        }
        public bool IsPointerOverUIElement()
        {
                return EventSystem.current.IsPointerOverGameObject();
        }


}