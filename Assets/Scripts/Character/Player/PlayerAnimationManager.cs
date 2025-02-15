
using System;

public class PlayerAnimationManager: AnimationManager
{
    protected Player player;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        SetFloatValueAnimation(player.PlayerPropertiesSO.NomalAttackValueTrigger,-1.0f);
    }

    public void AttackRight()
    {
        player.playerWeaponManager.AttackRightWeapon();
    }
    public void AttackLeft()
    {
        player.playerWeaponManager.AttackLeftWeapon();
    }
}