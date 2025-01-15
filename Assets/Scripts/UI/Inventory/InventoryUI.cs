using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : UIBase {
    // public event Action<InventoryItem> OnInventoryChanged;

    [SerializeField] private Button CloseButton;
    protected void Start()
    {
        
        CloseButton.onClick.AddListener(() => Hide());
        
        Hide();
    }

    
}