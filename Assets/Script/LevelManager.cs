using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool clearBackground = false;
    public bool madeFire = false;
    public bool drinkWater = false;
    public bool unboiledWater = false;
    public bool eatPosionedMushroom = false;
    public bool eatGoodMushroom = false;
    public GameObject backgroundObjects;
    public GameObject posionedMushroomDeadUI;
    public GameObject noWaterDeadUI;
    public GameObject drunkInPoolDeadUI;
    public GameObject rescueUI;

    public AudioClip rescueVoice;

    public static LevelManager instance = null;

    // Use this for initialization
    private void Start()
    {
        // create instance
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (clearBackground == true)
        {
            backgroundObjects.SetActive(false);
        }

        if (drinkWater == true && madeFire == true && eatGoodMushroom == true)
        {
            // get rescue voice over
            SoundManager.instance.playVoiceOver("rescueVoice;", rescueVoice);
            Debug.Log("Good Ending!");
        }
    }
}