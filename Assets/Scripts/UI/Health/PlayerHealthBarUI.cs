public class PlayerHealthBarUI: HealthBarUI
{
        protected override void Start()
        {
                character = GameManager.instance.Player;
                base.Start();
        }
}