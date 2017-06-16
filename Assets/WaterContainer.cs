using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class WaterContainer: MonoBehaviour {

	[Tooltip("the first child object should be the water to make sure the script work.")]
	private Transform waterInCup;
	private float fillSpeed = 2f;
	private float degreeToPoolWater = 90f;
	private AudioSource[] waterSoundEffects;
	float t  = 0;
	const float emptyCupScale = 0.0001f;
	const float fullCupScale = 1f;
    public int waitDrinkTime;

    public BlurOptimized blurEffect;
    public AudioClip dizzyBlurSound;
    public int blurTime;

    public static WaterContainer instance = null;

    // Use this for initialization
    void Start () {
		waterInCup = GameObject.Find("WaterInCup").transform;
		//waterInCup.gameObject.SetActive (false);
		waterSoundEffects = GetComponents<AudioSource> ();

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
				EmptyCup ();
				//Debug.Log ("EmptyCup");
			}
			t = 0;
		}

        if (LevelManager.instance.drinkWater == true && LevelManager.instance.unboiledWater == true)
        {
            Timer.instance.displaySeconds = Timer.instance.displaySeconds - Timer.instance.unBoiledWaterPunishSeconds;
            Debug.Log("Punished seconds for drinking unboiled water");
            blurEffect.blur.enabled = true;
            SoundManager.instance.playSingle("dizzyBlurSound", dizzyBlurSound);
            StartCoroutine(WaitToBlurRemove());
        }

        if (LevelManager.instance.drinkWater == true && LevelManager.instance.unboiledWater == false)
        {
            // drink boiled water
        }
    }
	void OnTriggerStay(Collider coll){
		
		if(coll.tag == "Waterfall"){
			//Fill the Cup
			if (waterInCup.localScale.y<fullCupScale) {
				//waterInCup.gameObject.SetActive (true);
				FillCup ();
			}
			t = 0;

            LevelManager.instance.unboiledWater = true;

            StartCoroutine(WaitToDrink());

        }
        else if(coll.tag == "Player"){
			//Empty the Cup
			if (waterInCup.localScale.y>emptyCupScale) {
				EmptyCup ();
                LevelManager.instance.drinkWater = true;
                //LevelManager.instance.rescueUI.SetActive(true);
                //LevelManager.instance.clearBackground = true;
            }
			t = 0;
		}
	}
		

	void EmptyCup(){
		
		t += fillSpeed * Time.deltaTime;
		waterInCup.localScale = new Vector3 (waterInCup.localScale.x, Mathf.Lerp (waterInCup.localScale.y, emptyCupScale, t), waterInCup.localScale.z);
		//waterInCup.gameObject.SetActive (false);
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
