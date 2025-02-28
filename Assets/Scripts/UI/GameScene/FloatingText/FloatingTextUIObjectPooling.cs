using UnityEngine;

public class FloatingTextUIObjectPooling: ObjectPooling
{
    public void ShowFloatingHP(Transform parent,string text, Vector3 position, Color color)
    {
        GameObject floatText = GetObject("FloatingText");
        floatText.transform.SetParent(parent);
        floatText.GetComponentInChildren<FloatingTextUI>().floatingTextUIObjectPooling = this;
        floatText.GetComponentInChildren<FloatingTextUI>().Setup(text, color);
        
    }
}