using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    [Header("Sound Effects")]
    public AudioSource eatMushroomSound;

    public AudioSource dizzyBlurSound;
    public AudioSource twoMinuteSoundRemind;
    public AudioSource oneMinuteSoundRemind;
    public AudioSource rescueVoice;
    public AudioSource posionedMushroomVoice;
    public AudioSource dehydratedVoice;
    public AudioSource openingVoice;
    public AudioSource deathVoiceClip;

    public AudioClip openingVoiceClip;

    // Use this for initialization
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        playVoiceOver("openingVoice", openingVoiceClip);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void playSingle(string audioSource, AudioClip sound)
    {
        if (audioSource == "eatMushroomSound")
        {
            eatMushroomSound.clip = sound;
            eatMushroomSound.Play();
            eatMushroomSound.loop = false;
            dizzyBlurSound.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "dizzyBlurSound")
        {
            dizzyBlurSound.clip = sound;
            dizzyBlurSound.Play();
            dizzyBlurSound.volume = 0.3f;
            Debug.Log("is playing" + sound.name);
        }
    }

    public void stopSingle(string audioSource, AudioClip sound)
    {
        if (audioSource == "eatMushroomSound")
        {
            eatMushroomSound.clip = sound;
            eatMushroomSound.Stop();
            eatMushroomSound.loop = false;
            Debug.Log("is stopping" + sound.name);
        }

        if (audioSource == "dizzyBlurSound")
        {
            dizzyBlurSound.clip = sound;
            dizzyBlurSound.Stop();
            Debug.Log("is stopping" + sound.name);
        }
    }

    public void playVoiceOver(string audioSource, AudioClip sound)
    {
        if (audioSource == "twoMinuteSoundRemind")
        {
            twoMinuteSoundRemind.clip = sound;
            twoMinuteSoundRemind.Play();
            twoMinuteSoundRemind.loop = false;
            twoMinuteSoundRemind.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "oneMinuteSoundRemind")
        {
            oneMinuteSoundRemind.clip = sound;
            oneMinuteSoundRemind.Play();
            oneMinuteSoundRemind.loop = false;
            oneMinuteSoundRemind.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "rescueVoice")
        {
            rescueVoice.clip = sound;
            rescueVoice.Play();
            rescueVoice.loop = false;
            rescueVoice.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "posionedMushroomVoice")
        {
            posionedMushroomVoice.clip = sound;
            posionedMushroomVoice.Play();
            posionedMushroomVoice.loop = false;
            posionedMushroomVoice.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "dehydratedVoice")
        {
            dehydratedVoice.clip = sound;
            dehydratedVoice.Play();
            dehydratedVoice.loop = false;
            dehydratedVoice.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "openingVoice")
        {
            openingVoice.clip = sound;
            openingVoice.Play();
            openingVoice.loop = false;
            openingVoice.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "deathVoiceClip")
        {
            deathVoiceClip.clip = sound;
            deathVoiceClip.Play();
            deathVoiceClip.loop = false;
            deathVoiceClip.volume = 1;
            Debug.Log("is playing" + sound.name);
        }
    }

    public void stopVoiceOver(string audioSource, AudioClip sound)
    {
        if (audioSource == "twoMinuteSoundRemind")
        {
            twoMinuteSoundRemind.clip = sound;
            twoMinuteSoundRemind.Stop();
            twoMinuteSoundRemind.loop = false;
            Debug.Log("is stopping" + sound.name);
        }

        if (audioSource == "oneMinuteSoundRemind")
        {
            oneMinuteSoundRemind.clip = sound;
            oneMinuteSoundRemind.Stop();
            oneMinuteSoundRemind.loop = false;
            Debug.Log("is stopping" + sound.name);
        }

        if (audioSource == "rescueVoice")
        {
            rescueVoice.clip = sound;
            rescueVoice.Stop();
            rescueVoice.loop = false;
            rescueVoice.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "posionedMushroomVoice")
        {
            posionedMushroomVoice.clip = sound;
            posionedMushroomVoice.Stop();
            posionedMushroomVoice.loop = false;
            posionedMushroomVoice.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "dehydratedVoice")
        {
            dehydratedVoice.clip = sound;
            dehydratedVoice.Stop();
            dehydratedVoice.loop = false;
            dehydratedVoice.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "openingVoice")
        {
            openingVoice.clip = sound;
            openingVoice.Stop();
            openingVoice.loop = false;
            openingVoice.volume = 1;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "deathVoiceClip")
        {
            deathVoiceClip.clip = sound;
            deathVoiceClip.Stop();
            deathVoiceClip.loop = false;
            deathVoiceClip.volume = 1;
            Debug.Log("is playing" + sound.name);
        }
    }
}