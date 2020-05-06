/**
 * $File: JCS_3DWalkActionManager.cs $
 * $Date: 2020-05-06 22:44:11 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *	                 Copyright © 2020 by Shen, Jen-Chieh $
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JCSUnity
{
    /// <summary>
    /// Manages all the 3D walk action in scene.
    /// </summary>
    public class JCS_3DWalkActionManager
        : JCS_Managers<JCS_3DWalkActionManager>
    {
        /* Variables */

        [Header("** Check Variables (JCS_3DWalkActionManager) **")]

        [Tooltip("All walk action that get manages.")]
        [SerializeField]
        private List<JCS_3DWalkAction> mWalkActions = null;

        /* Setter & Getter */
        
        public List<JCS_3DWalkAction> WalkActions { get { return this.mWalkActions; } }

        /* Functions */

        private void Awake()
        {
            instance = this;
        }

        /// <summary>
        /// Add walk action to get manage.
        /// </summary>
        /// <param name="wa"> Target walk action you want to get manage. </param>
        public void AddWalkAction(JCS_3DWalkAction wa)
        {
            mWalkActions = JCS_Utility.RemoveEmptySlotIncludeMissing<JCS_3DWalkAction>(mWalkActions);

            mWalkActions.Add(wa);
        }

        /// <summary>
        /// Check if there are other walk action having the same destination.
        /// </summary>
        /// <param name="targetPos"> Current targeting position. </param>
        /// <param name="overlapDistance"> Allow overlapping distance. </param>
        /// <returns>
        /// Return true, if it does overlaps with other walk action.
        /// Return false, if it does NOT overlap with other walk action.
        /// </returns>
        public bool OverlapWithOthers(Vector3 targetPos, float overlapDistance)
        {
            foreach (JCS_3DWalkAction wa in mWalkActions)
            {
                Vector3 dest = wa.navMeshAgent.destination;
                float distance = Vector3.Distance(targetPos, dest);
                if (distance < overlapDistance)
                    return true;
            }
            return false;
        }
    }
}
