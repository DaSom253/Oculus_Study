using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //GameManager.instance.audioManager.Play(AudioManager.AudioType.Shoot, true);

    [SerializeField] AudioSource shootSound = null;
    [SerializeField] AudioSource snowAoeSound = null;


    public enum AudioType
    {
        Shoot, SnowAoe
    }


    public void Play(AudioType audioType, bool playState)
    {
        AudioSource audioSource = null;
        switch (audioType)
        {
            case AudioType.Shoot:
                audioSource = shootSound;
                break;
            case AudioType.SnowAoe:
                audioSource = snowAoeSound;
                break;
        }
        if (audioSource != null)
        {
            if (playState)
            {
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
}
