using UnityEngine;
using System;

public class CollisionCounter : MonoBehaviour 
{
	[SerializeField] private int countTarget;

	private AudioSource audioSource;
	private event Action onReachCountTarget;
	private int counter;
	private bool isInsideArea;

	public bool IsInsideArea { get { return isInsideArea; } set { isInsideArea = value; } }
	public event Action OnReachCountTarget { add { onReachCountTarget += value; } remove { onReachCountTarget -= value; } }

	private void Awake()
	{
		audioSource = GetComponent<AudioSource> ();
	}

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
			if(other.tag == this.tag)
			{
				counter++;
				audioSource.Play ();

				if(counter == countTarget)
				{
					//Ignite campfire
					if(onReachCountTarget != null)
					{
						onReachCountTarget.Invoke();
					}
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
