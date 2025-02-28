using UnityEngine;

public class PlayerHealthBarUI: HealthBarUI
{
        protected override void Start()
        {
                character = GameManager.Instance.Player;
                base.Start();
        }
}