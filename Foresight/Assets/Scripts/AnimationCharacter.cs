using System.Collections;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private string animationNameGoLeft;
    [SerializeField] private string animationNameGoRight;
    [SerializeField] private string animationNameJump;

    [SerializeField] private ParticleSystem deadExplosionParticle;

    void Start()
    {
        _animator = GetComponent<Animator>();
        GameplayManager.Instance.moveLeft += MovementAnimLeft;
        GameplayManager.Instance.moveRight += MovementAnimRight;
        GameplayManager.Instance.moveUp += MovementAnimRight;
        GameplayManager.Instance.moveDown += MovementAnimLeft;
        GameplayManager.Instance.deadCondition += DeadAnim;
    }

    void MovementAnimLeft()
    {
        if (_animator != null) { _animator.SetTrigger(animationNameGoLeft); }
    }

    void MovementAnimRight()
    {
        if (_animator != null) { _animator.SetTrigger(animationNameGoRight); }
    }

    void DeadAnim()
    {
        StartCoroutine(DeadAnimationTimer());
    }

    IEnumerator DeadAnimationTimer()
    {
        yield return new WaitForSeconds(0.5f);
        if (_animator != null)
        {
            _animator.SetTrigger("Dead");
        }
        yield return new WaitForSeconds(0.4f);
        Instantiate(deadExplosionParticle, transform.position, Quaternion.identity);
    }
}
