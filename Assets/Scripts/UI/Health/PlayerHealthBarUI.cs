using UnityEngine;

public class PlayerHealthBarUI: HealthBarUI
{
        protected override void OnEnable()
        {
                character = GameManager.Instance.Player;
                base.OnEnable();
        }
}