using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Player _player;
    
    private static readonly int Crouch = Animator.StringToHash("Crouch");
    private static readonly int Stand = Animator.StringToHash("Stand");


    void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        // _player.OnCrouch += PlayCrouchAnimation;
        // _player.OnStand += PlayStandAnimation;
    }

    private void PlayCrouchAnimation()
    {
        _animator.SetTrigger(Crouch);
    }
    
    private void PlayStandAnimation()
    {
        _animator.SetTrigger(Stand);
    }
}
