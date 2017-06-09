using UnityEngine;
using System;

public class CollisionCounter : MonoBehaviour 
{
	[SerializeField] private string objectTag;
	[SerializeField] private int countTarget;

	private event Action onReachCountTarget;
	private int counter;
	private bool isInsideArea;

	public bool IsInsideArea { get { return isInsideArea; } set { isInsideArea = value; } }
	public event Action OnReachCountTarget { add { onReachCountTarget += value; } remove { onReachCountTarget -= value; } }

	private void Start()
	{
		ResetCounter ();
		isInsideArea = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		//Check if rock is inside campfire area
		if(isInsideArea)
		{
			if(other.tag == objectTag)
			{
				counter++;
				if(counter == countTarget)
				{
					//Ignite campfire
					onReachCountTarget.Invoke();
				}
			}
		}
	}

	//This is called when the player leave the campfire area
	public void ResetCounter()
	{
		counter = 0;
	}
}
