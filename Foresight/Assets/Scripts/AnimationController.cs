using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _lockAnimation;
    void Start()
    {
        var lockAnimationObject = GameObject.Find("lock_0");
        _lockAnimation = lockAnimationObject.GetComponent<Animator>();
        GameplayManager.Instance.UnlockPortal += UnlockLock;
    }

    void UnlockLock()
    {
        _lockAnimation.SetTrigger("Unlock");
        GameplayManager.Instance.isLockUnlocked = true;
    }
}
