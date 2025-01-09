using System;
using ImprovedTimer;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    private void Update()
    {
        TimerManager.UpdateTimers();
    }
}