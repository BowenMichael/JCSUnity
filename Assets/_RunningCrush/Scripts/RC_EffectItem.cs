﻿/**
 * $File: RC_EffectItem.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using System.Collections;
using JCSUnity;

[RequireComponent(typeof(RC_EffectObject))]
public class RC_EffectItem 
    : JCS_Item
{
    /* Variables */

    private RC_EffectObject mEffectObject = null;

    /* Setter & Getter */

    /* Functions */

    protected override void Awake()
    {
        base.Awake();

        // set to auto pick auto matically.
        mAutoPickColliderTouched = true;

        mEffectObject = this.GetComponent<RC_EffectObject>();

        // disable auto detect
        mEffectObject.AutoEffect = false;

        SetPickCallback(PickCallback);
    }

    private void PickCallback(Collider other)
    {
        // apply effect to player
        RC_Player p = other.GetComponent<RC_Player>();
        if (p == null)
        {
            JCS_Debug.LogError("You are using RC game object but the player isn't RC gameobject...");
            return;
        }

        mEffectObject.DoEffect(p);
    }
}
