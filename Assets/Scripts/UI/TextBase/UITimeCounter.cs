using System;
using TMPro;

public class UITimeCounter: UITextBase
{

        protected override void Start()
        {
                base.Start();
                GameManager.Instance.OnCounterTime += UpdateUIText;
        }

        protected override void UpdateUIText(string text)
        {
                text = text + "s";
                base.UpdateUIText(text);
        }
}