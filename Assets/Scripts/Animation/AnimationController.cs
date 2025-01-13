using UnityEngine;
public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void TriggerAnimation(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }

    public virtual void SetBoolValueAnimation(string triggerName, bool value)
    {
        animator.SetBool(triggerName, value);
    }

    public virtual void SetFloatValueAnimation(string triggerName, float value)
    {
        animator.SetFloat(triggerName, value);
    }

    public virtual bool GetBoolValueAnimation(string triggerName) {
        return animator.GetBool(triggerName);
    }
    public virtual float GetFloatValueAnimation(string triggerName) {
        return animator.GetFloat(triggerName);
    }
    
    public virtual bool IsAnimationEnded(string animationName,int layerIndex)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);

        if (stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1f)
        {
            return true;
        }

        return false;
    }
}