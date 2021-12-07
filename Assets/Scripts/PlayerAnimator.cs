using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
    private Health _health;

    private static readonly int Attack1 = Animator.StringToHash("Attack1");
    private static readonly int Die = Animator.StringToHash("Die");


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<Player>();
        _health = _player.GetComponent<Health>();
    }

    private void Start()
    {
        _player.OnAttack += PlayAttackAnimation;
        _player.OnStopAttack += StopAttackAnimation;
        _health.OnDeath += PlayDeathAnimation;
    }

    private void PlayDeathAnimation(Health health)
    {
        _animator.SetTrigger(Die);
    }

    private void PlayAttackAnimation()
    {
        _animator.SetBool(Attack1, true);
    }


    private void StopAttackAnimation()
    {
        _animator.SetBool(Attack1, false);
    }
}