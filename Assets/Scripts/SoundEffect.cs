using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    AudioSource audioSource;
    Player player;
    public SOSoundEffect sOSoundEffect;

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
        AudioSource.PlayClipAtPoint(sOSoundEffect.jumpEffect, Camera.main.transform.position);
    }
    private void PlayCrouchSound()
    {
        AudioSource.PlayClipAtPoint(sOSoundEffect.crouchEffect, Camera.main.transform.position);
    }
    private void PlayAttackSound()
    {
        AudioSource.PlayClipAtPoint(sOSoundEffect.attackEffect, Camera.main.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
