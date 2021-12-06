using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Player _player;

    private static readonly int Attack1 = Animator.StringToHash("Attack1");


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        _player.OnAttack += PlayAttackAnimation;
        _player.OnStopAttack += StopAttackAnimation;
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