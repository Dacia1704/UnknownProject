public class EnemyAnimationManager: AnimationManager {
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }
}