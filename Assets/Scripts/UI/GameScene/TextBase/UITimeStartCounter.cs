using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UITimeStartCounter: UITextBase
{


        protected override void Start()
        {
                base.Start();
                GameManager.Instance.OnCounterTimeStartGame += UpdateUIText;
                textMesh.DOFade(0f, 0f);
        }

        protected override void UpdateUIText(string text)
        {
                if (int.Parse(text) < 0)
                {
                        PlayScaleAndFadeEffect();
                        DisableAfterFade();
                }

                if (int.Parse(text) == 0)
                {
                        text = "Game Start";
                }
                base.UpdateUIText(text);
                PlayScaleAndFadeEffect();
        }
}