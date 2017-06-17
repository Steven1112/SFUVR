using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

[RequireComponent(typeof(BlurOptimized))]
public class MushroomSelection : MonoBehaviour
{
    public BlurOptimized blurEffect;
    public int blurTime;
    public AudioClip eatMushroomSound;
    public AudioClip dizzyBlurSound;

    public void Start()
    {
        blurEffect.blur.enabled = true;
    }

    // Update is called once per frame
    public void Update()
    {
    }

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("Tag name:" + col.gameObject.tag);
        if (string.Equals(col.gameObject.tag, "goodmushroom"))
        {
            // trigger unicorn and dizzy effect
            // trigger sound
            LevelManager.instance.eatGoodMushroom = true;
            SoundManager.instance.playSingle("eatMushroomSound", eatMushroomSound);
            col.gameObject.SetActive(false);
        }

        if (string.Equals(col.gameObject.tag, "rainbowmushroom"))
        {
            // trigger rainbow effect
            // trigger sound
            SoundManager.instance.playSingle("eatMushroomSound", eatMushroomSound);
            col.gameObject.SetActive(false);
        }

        if (string.Equals(col.gameObject.tag, "posionmushroom"))
        {
            // trigger posion effect
            // trigger sound
            SoundManager.instance.playSingle("eatMushroomSound", eatMushroomSound);
            col.gameObject.SetActive(false);
            blurEffect.blur.enabled = true;
            SoundManager.instance.playSingle("dizzyBlurSound", dizzyBlurSound);

            LevelManager.instance.eatPosionedMushroom = true;

            Timer.instance.countDownSeconds = Timer.instance.countDownSeconds - Timer.instance.posionedMushroomPunishSeconds;
            Debug.Log("Punished seconds for eating posioned mushroom");

            StartCoroutine(WaitToBlurRemove());
        }


        /*
        if (string.Equals(col.gameObject.tag, "poolArea"))
        {
            // get drunk into the pool and dead
            Debug.Log("Getting into the pool!");
            DeadInPool();
        }

       */
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("Tag name:" + col.gameObject.tag);
        if (string.Equals(col.gameObject.tag, "goodmushroom"))
        {
            // trigger sound
            SoundManager.instance.playSingle("eatMushroomSound", eatMushroomSound);
            col.gameObject.SetActive(false);
        }

        if (string.Equals(col.gameObject.tag, "rainbowmushroom"))
        {
            // trigger rainbow effect
            // trigger sound
            SoundManager.instance.playSingle("eatMushroomSound", eatMushroomSound);
            col.gameObject.SetActive(false);
        }

        if (string.Equals(col.gameObject.tag, "posionmushroom"))
        {
            // trigger posion effect
            // trigger sound
            SoundManager.instance.playSingle("eatMushroomSound", eatMushroomSound);
            col.gameObject.SetActive(false);
            blurEffect.blur.enabled = true;
            SoundManager.instance.playSingle("dizzyBlurSound", dizzyBlurSound);

            LevelManager.instance.eatPosionedMushroom = true;

            Timer.instance.displaySeconds = Timer.instance.displaySeconds - Timer.instance.posionedMushroomPunishSeconds;
            Debug.Log("Punished seconds for eating posioned mushroom");

            StartCoroutine(WaitToBlurRemove());
        }

        /*
        if (string.Equals(col.gameObject.tag, "poolArea"))
        {
            // get drunk into the pool and dead
            Debug.Log("Getting into the pool!");
            DeadInPool();
        }
        */
    }

    // ate posioned mushroom getting blur for seconds to dead end
    IEnumerator WaitToBlurRemove()
    {
        yield return new WaitForSeconds(blurTime);
        blurEffect.blur.enabled = false;
        SoundManager.instance.stopSingle("dizzyBlurSound", dizzyBlurSound);
    }

    // trigger in pool dead end
    public void DeadInPool()
    {
        LevelManager.instance.drunkInPoolDeadUI.SetActive(true);
        LevelManager.instance.clearBackground = true;
    }
}