using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchVoiceManager : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip[] blocks;
    public AudioClip intro;
    public AudioClip jab;
    public AudioClip laugh;
    public AudioClip[] pain;
    public AudioClip[] powerAttack;
    public AudioClip special;

    private void Start()
    {
        IntroWitch();
    }
    public void IntroWitch()
    {
        audioPlayer.clip = intro;
        audioPlayer.Play();
    }
    public void BlockWitch()
    {
        audioPlayer.clip = blocks[Random.Range(0, blocks.Length - 1)];
        audioPlayer.Play();
    }
    public void JabWitch()
    {
        audioPlayer.clip = jab;
        audioPlayer.Play();
    }
    public void LaughWitch()
    {
        audioPlayer.clip = laugh;
        audioPlayer.Play();
    }
    public void PainWitch()
    {
        audioPlayer.clip = pain[Random.Range(0, blocks.Length - 1)];
        audioPlayer.Play();
    }
    public void PowerAttackWitch()
    {
        audioPlayer.clip = powerAttack[Random.Range(0, blocks.Length - 1)];
        audioPlayer.Play();
    }
    public void SpecialWitch()
    {
        audioPlayer.clip = special;
        audioPlayer.Play();
    }
}
