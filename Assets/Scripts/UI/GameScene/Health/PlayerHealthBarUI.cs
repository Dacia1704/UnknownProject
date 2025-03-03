using UnityEngine;

public class PlayerHealthBarUI: HealthBarUI
{
        protected override void Awake()
        {
                character = GameManager.Instance.Player;
                base.Awake();
        }
}