using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class EyeBlink : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private bool blink;

    [SerializeField]
    private float blinkDelay;

    [SerializeField]
    private float blurDelay;

    public GameObject up;
    public GameObject down;
    public BlurOptimized blurEffect;

    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
        blink = true;
        StartCoroutine(StopBlinkAndBlurInDelay(blinkDelay));
        StartCoroutine(StopBlurInDelay(blurDelay));
    }

    // Update is called once per frame
    private void Update()
    {
        if (blink)
        {
            StartCoroutine(BlinkDelayInCertainSpeed(3f, 1f));
        }
        else {
            StopCoroutine("BlinkDelayInCertainSpeed");
        }
    }

    public IEnumerator BlinkDelayInCertainSpeed(float time, float speed)
    {
        anim.SetTrigger("EyeBlink");
        yield return new WaitForSeconds(time);
        anim.speed = speed;
        anim.SetTrigger("EyeBlink");
    }

    public void GoBlink()
    {
        blink = true;
    }

    public void DonotBlink()
    {
        blink = false;
    }

    public IEnumerator StopBlinkAndBlurInDelay(float times)
    {
        yield return new WaitForSeconds(times);
        blink = false;
        up.SetActive(false);
        down.SetActive(false);
    }

    public IEnumerator StopBlurInDelay(float times)
    {
        yield return new WaitForSeconds(times);
        blurEffect.blur.enabled = false;
    }
}