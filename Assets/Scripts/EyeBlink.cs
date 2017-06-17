using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class EyeBlink : MonoBehaviour {

	private Animator anim; 
	[SerializeField]
	private bool blink;
    [SerializeField]
    private float delay;
    public BlurOptimized blurEffect;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator> ();
        blink = true;
        StartCoroutine(StopBlinkAndBlurInDelay(delay));
    }

    // Update is called once per frame
    void Update () {
		if (blink) {
			StartCoroutine (BlinkDelayInCertainSpeed (1, 0.5f));
		} else {
			StopCoroutine ("BlinkDelayInCertainSpeed");
		}
	}


	public IEnumerator BlinkDelayInCertainSpeed(int time, float speed){
        anim.SetTrigger("EyeBlink");
        yield return new WaitForSeconds (time);
		anim.speed = speed;
		anim.SetTrigger ("EyeBlink");

	}

	public void GoBlink(){
		blink = true;
	}
	public void DonotBlink(){
		blink = false;
	}
    public IEnumerator StopBlinkAndBlurInDelay(float times)
    {
        yield return new WaitForSeconds(times);
        blink = false;
        blurEffect.blur.enabled = false;
    }
}
