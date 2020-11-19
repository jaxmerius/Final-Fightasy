using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianVoiceManager : MonoBehaviour
{
    public AudioSource soundPlayer;

    public AudioClip[] painSounds;
    public AudioClip powerAttack;
    public AudioClip jab;
    public AudioClip charging;
    public AudioClip hiYa;
    public AudioClip celebrate;
    public AudioClip intro;
    void Start()
    {
        soundPlayer.clip = intro;
        soundPlayer.Play();
    }

    public void Pain()
    {
        soundPlayer.clip = painSounds[Random.Range(0, painSounds.Length - 1)];
        soundPlayer.Play();
    }

    public void PowerAttack()
    {
        soundPlayer.clip = powerAttack;
        soundPlayer.Play();
    }

    public void Jab()
    {
        soundPlayer.clip = jab;
        soundPlayer.Play();
    }

    public void Charging()
    {
        soundPlayer.clip = charging;
        soundPlayer.Play();
    }

    public void HiYa()
    {
        soundPlayer.clip = hiYa;
        soundPlayer.Play();
    }

    public void Celebrate()
    {
        soundPlayer.clip = celebrate;
        soundPlayer.Play();
    }
}
