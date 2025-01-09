using System;
using UnityEngine;

[Serializable]
public static class PlayerReusableData
{
    public static Vector2 MovementInput;
    
    
    public static bool IsGround;
    public static bool IsLeaveGround = false;

    public static bool IsIdle;
    public static bool IsMoving;
    public static bool IsDashing;
    public static bool IsNomalAttacking = false;
    


}