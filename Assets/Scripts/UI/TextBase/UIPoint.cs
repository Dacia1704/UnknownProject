using System;
using TMPro;

public class UIPoint: UITextBase
{
    protected override void Start()
    {
        base.Start();
        GameManager.Instance.OnPointChange += UpdateUIText;
    }
}