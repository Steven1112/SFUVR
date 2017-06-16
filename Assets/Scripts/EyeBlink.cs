using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlink : MonoBehaviour {

	private Animator anim; 
	[SerializeField]
	private bool blink;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (blink) {
			StartCoroutine (BlinkDelayInCertainSpeed (1, 1));
		} else {
			StopCoroutine ("BlinkDelayInCertainSpeed");
		}
	}


	public IEnumerator BlinkDelayInCertainSpeed(int time, float speed){

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

}
