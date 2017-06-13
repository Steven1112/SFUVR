﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public bool clearBackground = false;
    public bool madeFire = false;
    public bool drinkWater = false;
    public GameObject backgroundObjects;
    public GameObject posionedMushroomDeadUI;
    public GameObject noWaterDeadUI;
    public GameObject drunkInPoolDeadUI;
    public GameObject rescueUI;

    public static LevelManager instance = null;

    // Use this for initialization
    void Start()
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
    void Update () {
		
        if(clearBackground == true)
        {
            backgroundObjects.SetActive(false);
        }

	}
}
