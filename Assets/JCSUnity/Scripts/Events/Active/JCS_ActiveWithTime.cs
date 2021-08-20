/**
 * $File: JCS_ActiveWithTime.cs $
 * $Date: 2021-08-20 22:37:02 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *	                 Copyright © 2021 by Shen, Jen-Chieh $
 */
using System.Collections.Generic;
using UnityEngine;

namespace JCSUnity
{
    /// <summary>
    /// Active the gameobject after a certain time.
    /// </summary>
    public class JCS_ActiveWithTime : MonoBehaviour
    {
        /* Variables */

        private float mTimer = 0.0f;

        [Header("** Runtime Variables (JCS_ActiveWithTime) **")]

        [Tooltip("GameObjects that take effect.")]
        [SerializeField]
        private List<GameObject> mGameObjects = null;

        [Tooltip("Take effect for this gameobject.")]
        [SerializeField]
        private bool mEffectSelf = true;

        [Tooltip("Time before active the gameobject.")]
        [SerializeField]
        private float mTime = 2.0f;

        /* Setter & Getter */

        public List<GameObject> GameObjects { get { return this.mGameObjects; } set { this.mGameObjects = value; } }
        public bool EffectSelf { get { return this.mEffectSelf; } set { this.mEffectSelf = value; } }
        public float time { get { return this.mTime; } set { this.mTime = value; } }

        /* Functions */

        private void Update()
        {
            mTimer += Time.deltaTime;

            if (mTime < mTimer)
            {
                // reset timer.
                mTimer = 0.0f;

                // active all
                foreach (var comp in mGameObjects)
                    comp.SetActive(true);

                // active this
                if (mEffectSelf)
                    this.gameObject.SetActive(true);
            }
        }
    }
}
