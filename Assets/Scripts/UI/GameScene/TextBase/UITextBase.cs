using DG.Tweening;
using TMPro;
using UnityEngine;

public abstract class UITextBase: UIBase
{
    protected TextMeshProUGUI textMesh;
    [SerializeField] private float scaleMultiplier = 1.5f;
    [SerializeField] private float fadeDuration = 0.5f;

    protected virtual void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
               
    }

    protected virtual void UpdateUIText(string text)
    {
        textMesh.text = text;
    }
    
    protected void PlayScaleAndFadeEffect()
    {
        textMesh.transform.localScale = Vector3.one;
        textMesh.DOFade(1, 0f);
        textMesh.transform.DOScale(scaleMultiplier, 0.2f).SetEase(Ease.OutBack)
            .OnComplete(() => textMesh.transform.DOScale(1f, 0.3f));
        textMesh.DOFade(0, fadeDuration).SetDelay(0.3f);
    }

    protected void DisableAfterFade()
    {
        textMesh.DOFade(0, fadeDuration).OnComplete(() => gameObject.SetActive(false));
    }
}