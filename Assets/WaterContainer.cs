using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class WaterContainer: MonoBehaviour {

	[Tooltip("the first child object should be the water to make sure the script work.")]
	private Transform waterInCup;
	private float fillSpeed = 2f;
	private float degreeToPoolWater = 180f;
	private AudioSource[] waterSoundEffects;
	float t  = 0;
	const float emptyCupScale = 0.0001f;
	const float fullCupScale = 1.5f;
	private bool haveWater;
    public int waitDrinkTime;

    public BlurOptimized blurEffect;
    public AudioClip dizzyBlurSound;
    public int blurTime;

    public static WaterContainer instance = null;

    // Use this for initialization
    void Start () {
		waterInCup = GameObject.Find("WaterInCup").transform;
		waterInCup.gameObject.SetActive (false);
		waterSoundEffects = GetComponents<AudioSource> ();
		haveWater = false;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

	void Update(){
		//When don't hold the cup in right rotation
		//Debug.Log(Quaternion.Angle(Quaternion.identity,transform.rotation));

		if(Quaternion.Angle(Quaternion.identity,transform.rotation)>=degreeToPoolWater){
			//Debug.Log ("EmptyCup");
			if (waterInCup.localScale.y>emptyCupScale) {
				waterInCup.gameObject.SetActive (true);
				EmptyCup ();

				//Debug.Log ("EmptyCup");

			}
			t = 0;
		}
    }

    public void OnTriggerEnter(Collider col)
    {
        if (string.Equals(col.gameObject.tag, "Player"))
        {

        }

    }

    void OnTriggerStay(Collider coll){
		//Debug.Log (coll.name);
		if (coll.tag == "Waterfall") {
			//Fill the Cup
			waterInCup.gameObject.SetActive (true);
			if (waterInCup.localScale.y < fullCupScale) {
				FillCup ();
			}
			t = 0;

            LevelManager.instance.unboiledWater = true;

            //StartCoroutine(WaitToDrink());

        } else if (coll.tag == "Player") {
			//Empty the Cup
			if (waterInCup.localScale.y > emptyCupScale) {
				EmptyCup ();
				waterInCup.gameObject.SetActive (false);
                LevelManager.instance.drinkWater = true;

                if (LevelManager.instance.drinkWater == true && LevelManager.instance.unboiledWater == true)
                {
                    Timer.instance.countDownSeconds = Timer.instance.countDownSeconds - Timer.instance.unBoiledWaterPunishSeconds;
                    Debug.Log("Punished seconds for drinking unboiled water");
                    blurEffect.blur.enabled = true;
                    SoundManager.instance.playSingle("dizzyBlurSound", dizzyBlurSound);
                    LevelManager.instance.drinkWater = false;
                    LevelManager.instance.unboiledWater = false;
                    StartCoroutine(WaitToBlurRemove());
                }

                if (LevelManager.instance.drinkWater == true && LevelManager.instance.unboiledWater == false)
                {
                    // drink boiled water
                }

            }
			t = 0;
		} else if (coll.tag == "BoneFire") {
            if (haveWater)
            {
                WaterBoiling();
                LevelManager.instance.unboiledWater = false;
            }
		}
	}

	void OnCollisionEnter(Collision coll){
		//Debug.Log (coll.gameObject.name);
	}
		

	void EmptyCup(){
		
		t += fillSpeed * Time.deltaTime;
		waterInCup.localScale = new Vector3 (waterInCup.localScale.x, Mathf.Lerp (waterInCup.localScale.y, emptyCupScale, t), waterInCup.localScale.z);
		if (!waterSoundEffects [1].isPlaying&&haveWater) {
			waterSoundEffects [1].Play();
			haveWater = false;
		} 
		waterInCup.gameObject.SetActive (false);


	}
	void WaterBoiling(){
        Debug.Log("water");
		if (!waterSoundEffects [2].isPlaying) {
			waterSoundEffects [2].Play();
		} 
	}

	void FillCup(){

		t += fillSpeed * Time.deltaTime;
		waterInCup.localScale = new Vector3 (waterInCup.localScale.x, Mathf.Lerp (waterInCup.localScale.y, fullCupScale, t), waterInCup.localScale.z);
		if (!waterSoundEffects [0].isPlaying) {
			waterSoundEffects [0].Play();
		} 
		haveWater = true;
	}

    // wait for seconds to no drink water dead end
    IEnumerator WaitToDrink()
    {
        yield return new WaitForSeconds(waitDrinkTime);

        // do something
    }

    IEnumerator WaitToBlurRemove()
    {
        yield return new WaitForSeconds(blurTime);
        blurEffect.blur.enabled = false;
        SoundManager.instance.stopSingle("dizzyBlurSound", dizzyBlurSound);
    }
}
