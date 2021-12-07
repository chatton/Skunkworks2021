using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    AudioSource audioSource;
    Player player;
    public SOSoundEffect sOSoundEffect;

    private Camera _camera;

    private void Awake()
    {
        // cache reference to prevent repeated search.
        _camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnJump += PlayJumpSound;
        player.OnCrouch += PlayCrouchSound;
        player.OnAttack += PlayAttackSound;
    }

    private void PlayJumpSound()
    {
        AudioSource.PlayClipAtPoint(sOSoundEffect.jumpEffect, _camera.transform.position);
    }

    private void PlayCrouchSound()
    {
        AudioSource.PlayClipAtPoint(sOSoundEffect.crouchEffect, _camera.transform.position);
    }

    private void PlayAttackSound()
    {
        AudioSource.PlayClipAtPoint(sOSoundEffect.attackEffect, _camera.transform.position);
    }
}