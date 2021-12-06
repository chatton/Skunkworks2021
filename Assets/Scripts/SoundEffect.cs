using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    AudioSource audioSource;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnJump += PlayJumpSound;
        
    }

    private void PlayJumpSound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
