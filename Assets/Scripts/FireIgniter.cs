using UnityEngine;

public class FireIgniter : MonoBehaviour
{
    [SerializeField]
    private string objectTag;

    private FireLightScript fireLight;
    private AudioSource audioSource;

    private void Awake()
    {
        fireLight = transform.parent.GetComponent<FireLightScript>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == objectTag)
        {
            CollisionCounter cc = other.GetComponent<CollisionCounter>();
            if (cc)
            {
                cc.IsInsideArea = true;
                cc.OnReachCountTarget += IgniteFire;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == objectTag)
        {
            CollisionCounter cc = other.GetComponent<CollisionCounter>();
            if (cc)
            {
                cc.IsInsideArea = false;
                cc.ResetCounter();
                cc.OnReachCountTarget -= IgniteFire;
            }
        }
    }

    public void IgniteFire()
    {
        fireLight.TurnOn(true);
        LevelManager.instance.madeFire = true;
        audioSource.Play();
    }
}