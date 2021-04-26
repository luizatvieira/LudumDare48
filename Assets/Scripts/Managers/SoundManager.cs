using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound {
        Buy,
        Collect,
        Explode,
        Drill
    }

    public static void StopAudioSource ( AudioSource audioSource )
    {
        audioSource.Stop();
    }

    public static void PlayAudioSource ( AudioSource audioSource )
    {
        audioSource.Play();
    }

    public static void PlaySound( Sound sound )
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot( GetAudioClip(sound) );
        GameAssets.i.DestroyGameObject(soundGameObject);
    }

    private static AudioClip GetAudioClip( Sound sound )
    {
        foreach( GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray )
        {
            if ( soundAudioClip.sound == sound ) 
            {
                return soundAudioClip.audioClip;
            }
        }
        return null;
    }
}
