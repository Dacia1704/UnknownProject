
using System;

public class PlayerAnimationController: AnimationController
{
    protected Player player;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        player.PlayerAnimationController.SetFloatValueAnimation(player.PlayerPropertiesSO.NomalAttackValueTrigger,-1.0f);
    }
}