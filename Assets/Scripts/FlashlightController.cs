using UnityEngine;
using VRTK;

public class FlashlightController : MonoBehaviour {

	[SerializeField] private AudioClip turnOnSfx;
	[SerializeField] private AudioClip turnOffSfx;

	private VRTK_InteractableObject interactableObject;
	private Light spotlight;
	private AudioSource audioSource;

	private void Awake()
	{
		spotlight = transform.Find ("Spotlight").GetComponent<Light>();
		audioSource = GetComponent<AudioSource> ();
	}

	private void Start()
	{
		interactableObject = GetComponent<VRTK_InteractableObject> ();
		interactableObject.InteractableObjectGrabbed += new InteractableObjectEventHandler(OnObjectGrabbed);
		//interactableObject.InteractableObjectUngrabbed += new InteractableObjectEventHandler(OnObjectUngrabbed);
	}

	private void OnObjectGrabbed(object sender, InteractableObjectEventArgs e)
	{
		TurnOn (true);
		audioSource.clip = turnOnSfx;
		audioSource.Play ();
	}

	//private void OnObjectUngrabbed(object sender, InteractableObjectEventArgs e)
	//{
		//TurnOn (false);
		//audioSource.clip = turnOffSfx;
		//audioSource.Play ();
	//}

	private void TurnOn(bool b)
	{
		if(b)
		{
			spotlight.enabled = true;
		}
		else
		{
			spotlight.enabled = false;
		}
	}
}
