using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class randomly plays a sound between the min and max time. It also fades in and out the sound once it's triggered.
public class SoundTrigger : MonoBehaviour 
{
	[SerializeField] private float minRepeatTime = 20.0f; //seconds
	[SerializeField] private float maxRepeatTime = 30.0f; //seconds
	[SerializeField] private float fadeSpeed = 0.001f;

	private AudioSource audioSource;
	private bool isRunning;
	private bool fadeIn;
	private bool soundFade;
	private float animTime;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	private void Start()
	{
		StartPlaying ();
	}

	private void Update()
	{
		if (soundFade)
		{
			if(fadeIn)
			{
				SoundFade (0.0f, 1.0f);
			}
			else //Fade out
			{
				SoundFade (1.0f, 0.0f);
			}
		}
	}

	private IEnumerator TriggerSoundTimer()
	{
		float waitTimer = 0.0f;
		while(isRunning)
		{
			waitTimer = Random.Range (minRepeatTime, maxRepeatTime);
			yield return new WaitForSeconds (waitTimer); //Repeat the audio every "waitTimer" seconds

			PlaySoundFade ();
		}
		yield return null;
	}

	private void PlaySoundFade()
	{
		audioSource.volume = 0.0f;
		audioSource.Play ();
		fadeIn = true;
		soundFade = true;
	}

	private void SoundFade(float startValue, float endValue)
	{
		if(animTime <= 1.0f)
		{
			float ease;
			if(fadeIn)
			{
				ease = EasingFunction.EaseInCubic (startValue, endValue, animTime);
			}
			else
			{
				ease = EasingFunction.EaseOutCubic (startValue, endValue, animTime);
			}
			audioSource.volume = ease;

			animTime += fadeSpeed * Time.deltaTime;
		}
		else
		{
			animTime = 0.0f;
			if(fadeIn)
			{
				fadeIn = false;
			}
			else
			{
				audioSource.Stop ();
				soundFade = false;
			}
		}
	}

	public void StartPlaying()
	{
		soundFade = false;
		fadeIn = true;
		isRunning = true;
		StartCoroutine (TriggerSoundTimer());
	}

	public void StopPlaying()
	{
		isRunning = false;
		StopCoroutine (TriggerSoundTimer ());
	}
}
