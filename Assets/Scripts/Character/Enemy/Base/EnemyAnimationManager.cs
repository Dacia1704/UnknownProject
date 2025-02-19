using UnityEngine;

public class EnemyAnimationManager: AnimationManager {
    public void PlayAnimation(string animationName)
    {
        if (animator == null)
        {
            Debug.Log(gameObject.name + " null");
        }
        animator.Play(animationName);
    }
}