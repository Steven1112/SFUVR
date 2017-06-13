using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance = null;

    [Header("Sound Effects")]
    public AudioSource eatMushroomSound;
    public AudioSource dizzyBlurSound;

    // Use this for initialization
    void Start()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void playSingle(string audioSource, AudioClip sound)
    {
        if (audioSource == "eatMushroomSound")
        {
            eatMushroomSound.clip = sound;
            eatMushroomSound.Play();
            eatMushroomSound.loop = false;
            Debug.Log("is playing" + sound.name);
        }

        if (audioSource == "dizzyBlurSound")
        {
            dizzyBlurSound.clip = sound;
            dizzyBlurSound.Play();
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
}
