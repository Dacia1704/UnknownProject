using UnityEngine;

public class PlayerHealthBarUI: HealthBarUI
{
        protected override void OnEnable()
        {
                character = GameManager.instance.Player;
                base.OnEnable();
        }
}