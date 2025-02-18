using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class FloatingTextUI : UIBase,IPoolingObject
{
    private TextMesh textMesh; 
    private Color textColor;
    [field: SerializeField] public PoolingObjectPropsSO PoolingObjectPropsSO { get; set; }

    [HideInInspector]public FloatingTextUIObjectPooling floatingTextUIObjectPooling;

    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }
    

    public void Setup(string value, Color color)
    {
        transform.localPosition = Vector3.zero;
        textMesh.text = value.ToString();
        textMesh.color = color;
        textColor = color;
        transform.localScale = Vector3.zero;
        transform.DOMoveY(transform.localPosition.y + 0.5f, 0.5f).SetEase(Ease.OutExpo);
        transform.DOScale(new Vector3(0.5f,0.5f,0.5f), 0.5f).SetEase(Ease.OutBack).OnComplete(() => floatingTextUIObjectPooling.ReleaseObject(this.gameObject));
    }
    
    

    private void LateUpdate()
    {
        LookAtCamera();
    }
}
