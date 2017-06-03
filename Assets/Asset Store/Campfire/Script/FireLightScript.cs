using UnityEngine;

public class FireLightScript : MonoBehaviour
{
	public float minIntensity = 0.25f;
	public float maxIntensity = 0.5f;

	public float flickeringRate = 0.1f;
	private float flickering = 0.0f;

	public Light fireLight;

	float random;

	void FixedUpdate()
	{
		if(flickering >= flickeringRate)
		{
			random = Random.Range(0.0f, 150.0f);
			float noise = Mathf.PerlinNoise(random, Time.time);
			fireLight.GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
			flickering = 0.0f;
		}
		flickering += Time.deltaTime;
	}
}