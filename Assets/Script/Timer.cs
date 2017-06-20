using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;

    [HideInInspector]
    public int restSeconds;

    public int roundedRestSeconds;
    public int displaySeconds;
    public int displayMinutes;
    private string text;

    public Font font;
    public Texture2D timerImage;

    [HideInInspector]
    public float guiTime;

    public int countDownSeconds;   // in seconds
    public int posionedMushroomPunishSeconds;
    public int unBoiledWaterPunishSeconds;
    public static Timer instance = null;

    public AudioClip twoMinuteSoundRemind;
    public AudioClip oneMinuteSoundRemind;
    public AudioClip dehydratedVoice;
    public AudioClip deathVoiceClip;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GameObject controlPanel = GameObject.Find("Timer");
    }

    private void Awake()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        guiTime = Time.time - startTime;

        restSeconds = (int)(countDownSeconds - (guiTime));

        //display the timer
        roundedRestSeconds = Mathf.CeilToInt(restSeconds);
        displaySeconds = roundedRestSeconds % 60;
        displayMinutes = roundedRestSeconds / 60;

        // trigger voice over hint
        if (displaySeconds >= 0 || displayMinutes > 0)
        {
            text = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);

            if (displayMinutes < 4 && displaySeconds < 60)
            {
                //trigger voice over
                Debug.Log("Wondering too cold!");
                SoundManager.instance.playVoiceOver("dehydratedVoice", dehydratedVoice);
            }

            if (displayMinutes <= 2 && displaySeconds < 1 && displayMinutes > 1)
            {
                //trigger voice over hint
                Debug.Log("Two minute left!");
                SoundManager.instance.playVoiceOver("twoMinuteSoundRemind", twoMinuteSoundRemind);
            }

            if (displayMinutes <= 1 && displaySeconds < 1)
            {
                //trigger almost die voice over hint
                Debug.Log("One minute left!");
                SoundManager.instance.playVoiceOver("oneMinuteSoundRemind", oneMinuteSoundRemind);
            }
        }

        if (displaySeconds < 0)
        {
            displaySeconds = 0;
            text = string.Format("{0:00}:{1:00}", 0, 0);
            Debug.Log("Timers up, You die!");
            LevelManager.instance.dieEndUI.SetActive(true);
            LevelManager.instance.clearBackground = true;
            // death by cold sound
            SoundManager.instance.playVoiceOver("deathVoiceClip", deathVoiceClip);
        }

        // always do wrond actions will immediately die
        if (LevelManager.instance.unboiledWater == true && LevelManager.instance.eatPosionedMushroom == true)
        {
            displaySeconds = 0;
            displayMinutes = 0;
        }
    }

    /*
    void OnGUI()
    {
        GUI.skin.box.fontStyle = FontStyle.Bold;
        GUI.skin.box.fontSize = 100;
        GUI.skin.box.alignment = TextAnchor.MiddleCenter;
        GUI.skin.font = font;
        GUI.skin.button.fontStyle = FontStyle.Bold;
        GUI.skin.button.fontSize = 100;
        GUI.skin.button.alignment = TextAnchor.MiddleCenter;
        GUI.skin.box.normal.background = (Texture2D)timerImage;

        GUI.Box(new Rect(Screen.width / 2 - 200, 0, 400, 200), text);
    }
    */
}