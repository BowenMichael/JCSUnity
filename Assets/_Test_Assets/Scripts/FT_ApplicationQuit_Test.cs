﻿/**
 * $File: FT_ApplicationQuit_Test.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                 Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;
using JCSUnity;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>
public class FT_ApplicationQuit_Test
    : MonoBehaviour 
{
    /* Variables */

    /* Setter/Getter */

    /* Functions */

    private void Awake()
    {

    }

    private void Update()
    {
        if (JCS_Input.GetKeyDown(KeyCode.R))
        {
            JCS_UtilityFunctions.QuitApplicationWithSwithScene();
        }
    }
}
