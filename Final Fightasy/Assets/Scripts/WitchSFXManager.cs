using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchSFXManager : MonoBehaviour
{
    public AudioSource soundPlayer;

    public AudioClip powerAttack;
    public AudioClip charge;
    public AudioClip special;
    public AudioClip guard;
    public AudioClip jab;

    public void PowerSFXWitch()
    {
        soundPlayer.clip = powerAttack;
        soundPlayer.Play();
    }

    public void ChargeSFXWitch()
    {
        soundPlayer.clip = charge;
        soundPlayer.Play();
    }

    public void SpecialSFXWitch()
    {
        soundPlayer.clip = special;
        soundPlayer.Play();
    }

    public void GuardSFXWitch()
    {
        soundPlayer.clip = guard;
        soundPlayer.Play();
    }

    public void JabSFXWitch()
    {
        soundPlayer.clip = jab;
        soundPlayer.Play();
    }
}
