using System;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}