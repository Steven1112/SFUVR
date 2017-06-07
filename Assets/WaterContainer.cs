using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterContainer: MonoBehaviour {
	private Transform waterInCup;
	private float fillSpeed = 2f;
	private float degreeToPoolWater = 90f;
	float t  = 0;
	const float emptyCupScale = 0.0001f;
	const float fullCupScale = 1f;

	// Use this for initialization
	void Start () {
		waterInCup = transform.GetChild (0);

	}

	void Update(){
		//When don't hold the cup in right rotation

		if(Quaternion.Angle(Quaternion.identity,transform.rotation)>degreeToPoolWater){
			if (waterInCup.localScale.y>=emptyCupScale) {
				EmptyCup ();
			}
			t = 0;
		}
	}
	void OnTriggerStay(Collider coll){
		
		if(coll.tag == "Waterfall"){
			//Fill the Cup
			if (waterInCup.localScale.y<=fullCupScale) {
				FillCup ();
			}
			t = 0;
		}else if(coll.tag == "Player"){
			//Empty the Cup
			if (waterInCup.localScale.y>=emptyCupScale) {
				EmptyCup ();
			}
			t = 0;
		}
	}
		

	void EmptyCup(){
		
		t += fillSpeed * Time.deltaTime;
		waterInCup.localScale = new Vector3 (waterInCup.localScale.x, Mathf.Lerp (waterInCup.localScale.y, emptyCupScale, t), waterInCup.localScale.z);

	}

	void FillCup(){

		t += fillSpeed * Time.deltaTime;
		waterInCup.localScale = new Vector3 (waterInCup.localScale.x, Mathf.Lerp (waterInCup.localScale.y, fullCupScale, t), waterInCup.localScale.z);

	}
}
