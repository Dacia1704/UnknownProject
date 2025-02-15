using System;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public void Enable() {
        gameObject.SetActive(true);
    }

    public void Disable() {
        gameObject.SetActive(false);
    }
}