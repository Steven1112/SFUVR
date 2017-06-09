using UnityEngine;

public class FireIgniter : MonoBehaviour {

	[SerializeField] private string objectTag;

	private FireLightScript fireLight;

	private void Awake()
	{
		fireLight = transform.parent.GetComponent<FireLightScript> ();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == objectTag)
		{
			CollisionCounter cc = other.GetComponent<CollisionCounter> ();
			if(cc)
			{
				cc.IsInsideArea = true;
				cc.OnReachCountTarget += IgniteFire;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == objectTag)
		{
			CollisionCounter cc = other.GetComponent<CollisionCounter> ();
			if (cc) 
			{
				cc.IsInsideArea = false;
				cc.ResetCounter ();
				cc.OnReachCountTarget -= IgniteFire;
			}
		}
	}

	private void IgniteFire()
	{
		fireLight.TurnOn (true);
	}

}
