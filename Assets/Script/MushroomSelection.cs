using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

[RequireComponent(typeof(BlurOptimized))]
public class MushroomSelection : MonoBehaviour
{
    public BlurOptimized blurEffect;
    public int blurTime;

    public void Start()
    {
        blurEffect.blur.enabled = false;
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
            col.gameObject.SetActive(false);
        }

        if (string.Equals(col.gameObject.tag, "rainbowmushroom"))
        {
            // trigger rainbow effect
            // trigger sound
            col.gameObject.SetActive(false);
        }

        if (string.Equals(col.gameObject.tag, "posionmushroom"))
        {
            // trigger posion effect
            // trigger sound
            col.gameObject.SetActive(false);
            blurEffect.blur.enabled = true;
            StartCoroutine(WaitToDie());
        }

        if (string.Equals(col.gameObject.tag, "poolArea"))
        {
            // get drunk into the pool and dead
            Debug.Log("Getting into the pool!");
            DeadInPool();
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("Tag name:" + col.gameObject.tag);
        if (string.Equals(col.gameObject.tag, "goodmushroom"))
        {
            // trigger unicorn and dizzy effect
            // trigger sound
            col.gameObject.SetActive(false);
        }

        if (string.Equals(col.gameObject.tag, "rainbowmushroom"))
        {
            // trigger rainbow effect
            // trigger sound
            col.gameObject.SetActive(false);
        }

        if (string.Equals(col.gameObject.tag, "posionmushroom"))
        {
            // trigger posion effect
            // trigger sound
            col.gameObject.SetActive(false);
            blurEffect.blur.enabled = true;
            StartCoroutine(WaitToDie());
        }

        if (string.Equals(col.gameObject.tag, "poolArea"))
        {
            // get drunk into the pool and dead
            Debug.Log("Getting into the pool!");
            DeadInPool();
        }
    }

    // ate posioned mushroom getting blur for seconds to dead end
    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(blurTime);
        LevelManager.instance.clearBackground = true;
        blurEffect.blur.enabled = false;
        LevelManager.instance.posionedMushroomDeadUI.SetActive(true);
    }

    // trigger in pool dead end
    public void DeadInPool()
    {
        LevelManager.instance.drunkInPoolDeadUI.SetActive(true);
        LevelManager.instance.clearBackground = true;
    }
}