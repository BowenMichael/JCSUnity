﻿/**
 * $File: BF_RainFaller.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                    Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using JCSUnity;

/// <summary>
/// Character shoot rain fall
/// </summary>
[RequireComponent(typeof(JCS_ShootAction))]
public class BF_RainFaller : MonoBehaviour
{
    /* Variables */

    private JCS_ShootAction mShootAction = null;
    private BF_Player mBFPlayer = null;

    private float mShootAngle = 0;

    [Header("** Runtime Variables (BF_RainFaller) **")]

    [SerializeField] 
    private bool mCanShoot = true;

    [Header("** Time Settings (BF_RainFaller) **")]

    [Tooltip("Time to do one walk.")]
    [SerializeField]
    [Range(0.01f, 10.0f)]
    private float mTimeZone = 2.0f;

    [Tooltip("Time that will randomly affect the Time Zone.")]
    [SerializeField]
    [Range(0.0f, 3.0f)]
    private float mAdjustTimeZone = 1.5f;

    // time to record down the real time to do one walk 
    // action after we calculate the real time.
    private float mRealTimeZone = 0;

    // timer to do walk.
    private float mTimer = 0;

    // check to see if we can reset our time zone.
    private bool mShooted = false;

    /* Setter & Getter */

    /* Functions */

    private void Awake()
    {
        mShootAction = this.GetComponent<JCS_ShootAction>();
        mBFPlayer = this.GetComponent<BF_Player>();
    }

    private void Start()
    {
        switch (mBFPlayer.Face)
        {
            case JCS_2DFaceType.FACE_LEFT:
                mShootAngle = 90;
                break;
            case JCS_2DFaceType.FACE_RIGHT:
                mShootAngle = -90;
                break;
        }
    }

    private void Update()
    {
        DoRainFall();
    }

    public void ShootRainFall()
    {
        if (!mCanShoot)
            return;

        for (int count = 0; count < mShootAction.ShootCount; ++count)
        {
            JCS_Bullet bullet = mShootAction.Shoot();
            if (bullet != null)
            {
                bullet.transform.eulerAngles = new Vector3(0, 0, mShootAngle);
                mShootAction.DeviationEffect(bullet.transform);
            }
        }

        mShooted = true;
    }

    /// <summary>
    /// 
    /// </summary>
    private void DoRainFall()
    {
        if (mShooted)
            ResetTimeZone();

        mTimer += Time.deltaTime;

        if (mTimer < mRealTimeZone)
            return;

        ShootRainFall();
    }

    /// <summary>
    /// Algorithm to calculate the time to do 
    /// this action include direction.
    /// </summary>
    private void ResetTimeZone()
    {
        float adjustTime = JCS_Random.Range(-mAdjustTimeZone, mAdjustTimeZone);
        mRealTimeZone = mTimeZone + adjustTime;

        mShooted = false;
        mTimer = 0;
    }
}
