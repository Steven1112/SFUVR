using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

[RequireComponent(typeof(BlurOptimized))]
public class MushroomSelection : MonoBehaviour
{
    public BlurOptimized blurEffect;

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
        }
    }
}