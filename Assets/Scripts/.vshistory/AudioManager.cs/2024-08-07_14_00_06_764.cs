using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script to handle playing music and sound effects

public class AudioManager : MonoBehaviour
{
    public AudioSource music; // For playing the background track
    public AudioSource sfx; // For playing sound effects

    public AudioSource background; // Background track
    public AudioSource shoot; // Shooting a bullet
    public AudioSource hit; // Bullet hits player/enemy
    public AudioSource coin; // Player collects coin
    public AudioSource heal; // Player collects healing item

    void Start()
    {
        // Play the background track
        music.clip = background;
        music.Play();
    }
}
