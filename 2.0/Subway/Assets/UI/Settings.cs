﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider SlideVolume;


    public void Volume()
    {
        AudioListener.volume = SlideVolume.value;

    }
}