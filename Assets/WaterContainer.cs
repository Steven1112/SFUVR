using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterContainer: MonoBehaviour {

	[Tooltip("the first child object should be the water to make sure the script work.")]
	private Transform waterInCup;
	private float fillSpeed = 2f;
	private float degreeToPoolWater = 90f;
	private AudioSource[] waterSoundEffects;
	float t  = 0;
	const float emptyCupScale = 0.0001f;
	const float fullCupScale = 1f;

	// Use this for initialization
	void Start () {
		waterInCup = GameObject.Find("WaterInCup").transform;
		waterSoundEffects = GetComponents<AudioSource> ();
	}

	void Update(){
		//When don't hold the cup in right rotation
		//Debug.Log(Quaternion.Angle(Quaternion.identity,transform.rotation));
		if(Quaternion.Angle(Quaternion.identity,transform.rotation)>=degreeToPoolWater){
			Debug.Log ("EmptyCup");
			if (waterInCup.localScale.y>emptyCupScale) {
				EmptyCup ();
				//Debug.Log ("EmptyCup");
			}
			t = 0;
		}
	}
	void OnTriggerStay(Collider coll){
		
		if(coll.tag == "Waterfall"){
			//Fill the Cup
			if (waterInCup.localScale.y<fullCupScale) {
				FillCup ();
			}
			t = 0;
		}else if(coll.tag == "Player"){
			//Empty the Cup
			if (waterInCup.localScale.y>emptyCupScale) {
				EmptyCup ();
			}
			t = 0;
		}
	}
		

	void EmptyCup(){
		
		t += fillSpeed * Time.deltaTime;
		waterInCup.localScale = new Vector3 (waterInCup.localScale.x, Mathf.Lerp (waterInCup.localScale.y, emptyCupScale, t), waterInCup.localScale.z);
		if (!waterSoundEffects [1].isPlaying) {
			waterSoundEffects [1].Play();
		} 


	}

	void FillCup(){

		t += fillSpeed * Time.deltaTime;
		waterInCup.localScale = new Vector3 (waterInCup.localScale.x, Mathf.Lerp (waterInCup.localScale.y, fullCupScale, t), waterInCup.localScale.z);
		if (!waterSoundEffects [0].isPlaying) {
			waterSoundEffects [0].Play();
		} 
	}
}
