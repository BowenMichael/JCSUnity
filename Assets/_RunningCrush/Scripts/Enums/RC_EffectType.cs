﻿/**
 * $File: RC_EffectType.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;

public enum RC_EffectType 
{
    BLOCK,      // defualt
    
    SPEED_UP,
    SPEED_DOWN,

    WEAK,           // reduce jump force
    ENERGETIC,

    // get push by something.
    PUSH_UP, 
    PUSH_DOWN,
    
    // if liquid bar avaliable
    ADD_POINT,
    LOSE_POINT
}
