using UnityEngine;
using VRTK;

public class FlashlightController : MonoBehaviour {

	private VRTK_InteractableObject interactableObject;
	private Light spotlight;

	private void Awake()
	{
		spotlight = transform.Find ("Spotlight").GetComponent<Light>();
	}

	private void Start()
	{
		interactableObject = GetComponent<VRTK_InteractableObject> ();
		interactableObject.InteractableObjectGrabbed += new InteractableObjectEventHandler(OnObjectGrabbed);
		interactableObject.InteractableObjectUngrabbed += new InteractableObjectEventHandler(OnObjectUngrabbed);
	}

	private void OnObjectGrabbed(object sender, InteractableObjectEventArgs e)
	{
		TurnOn (true);
	}

	private void OnObjectUngrabbed(object sender, InteractableObjectEventArgs e)
	{
		//TurnOn (false);
	}

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
