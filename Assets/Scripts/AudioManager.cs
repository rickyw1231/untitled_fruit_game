using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle playing music and sound effects

public class AudioManager : MonoBehaviour
{
    public AudioSource music; // For playing the background track
    public AudioSource sfx; // For playing sound effects

    public AudioClip background; // Background track
    public AudioClip shoot; // Shooting a bullet
    public AudioClip hit; // Bullet hits player/enemy
    public AudioClip coin; // Player collects coin
    public AudioClip heal; // Player collects healing item

    void Start()
    {
        // Play the background track
        music.clip = background;
        music.Play();
    }
}
