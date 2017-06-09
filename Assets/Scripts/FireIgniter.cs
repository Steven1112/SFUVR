using UnityEngine;

public class FireIgniter : MonoBehaviour {

	private FireLightScript fireLight;

	private void Awake()
	{
		fireLight = transform.parent.GetComponent<FireLightScript> ();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "FireRock")
		{
			CollisionCounter cc = other.GetComponent<CollisionCounter> ();
			cc.IsInsideArea = true;
			cc.OnReachCountTarget += IgniteFire;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.tag == "FireRock")
		{
			CollisionCounter cc = other.GetComponent<CollisionCounter> ();
			cc.IsInsideArea = false;
			cc.ResetCounter ();
			cc.OnReachCountTarget -= IgniteFire;
		}
	}

	private void IgniteFire()
	{
		fireLight.TurnOn (true);
	}

}
