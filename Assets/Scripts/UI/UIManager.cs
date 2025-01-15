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
        
        [FormerlySerializedAs("InventoryButton")]
        [Header("Inventory")]
        [SerializeField] protected Button inventoryButton;
        [SerializeField]private InventoryUI inventoryUI;

        public event Action OnSwordButtonClicked;
        public event Action OnStaffButtonClicked;
        public event Action OnBowButtonClicked;
        

        private void Awake()
        {
                Instance = this;
                inventoryUI = GetComponentInChildren<InventoryUI>();
        }

        private void Start()
        {
                
                swordButton.onClick.AddListener(() => OnSwordButtonClicked?.Invoke());
                staffButton.onClick.AddListener(() => OnStaffButtonClicked?.Invoke());
                bowButton.onClick.AddListener(() => OnBowButtonClicked?.Invoke());
                inventoryButton.onClick.AddListener(() =>
                {
                        if (inventoryUI.gameObject.activeSelf) inventoryUI.Hide();
                        else inventoryUI.Show();
                });
        }
        
        
        public bool IsPointerOverUIElement()
        {
                return EventSystem.current.IsPointerOverGameObject();
        }
}