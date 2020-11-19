using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianSFXManager : MonoBehaviour
{
    public AudioSource soundPlayer;

    public AudioClip woosh;
    public AudioClip[] walk;
    public AudioClip[] takeDamage;
    public AudioClip slam;

    public void Walk()
    {
        soundPlayer.clip = walk[Random.Range(0, walk.Length - 1)];
        soundPlayer.Play();
    }

    public void Woosh()
    {
        soundPlayer.clip = woosh;
        soundPlayer.Play();
    }

    public void TakeDamage()
    {
        soundPlayer.clip = takeDamage[Random.Range(0, takeDamage.Length - 1)];
        soundPlayer.Play();
    }

    public void Slam()
    {
        soundPlayer.clip = slam;
        soundPlayer.Play();
    }

}
