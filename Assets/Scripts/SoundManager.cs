using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class SoundManager 
{
    public enum Sound
    {
        SnakeMove,
        SnakeDie,
        SnakeEat,
        ButtonClick,
        SnakePostEat,

    }


    public static void PlaySound( Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
       audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {

            if (soundAudioClip.sound ==sound)
            {
                return soundAudioClip.audioClip;
            }
        }return null;
    }


    public static void AddButtonSounds( this Button_UI button)
    {

    }
}
