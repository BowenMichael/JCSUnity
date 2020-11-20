﻿/**
 * $File: JCS_SlideScreenPanelHolder.cs $
 * $Date: $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information 
 *                   Copyright (c) 2016 by Shen, Jen-Chieh $
 */
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace JCSUnity
{
    /// <summary>
    /// Slide panel holder.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class JCS_SlideScreenPanelHolder
        : MonoBehaviour
    {
        /* Variables */

        private RectTransform mRectTransform = null;

        [Header("** Initialize Variables (JCS_SlideScreenPanelHolder) **")]

        [Tooltip("How fast the this slide panel slide in x axis.")]
        [SerializeField]
        [Range(0.01f, 5.0f)]
        private float mSlideFrictionX = 0.2f;

        [Tooltip("How fast the this slide panel slide in y axis.")]
        [SerializeField]
        [Range(0.01f, 5.0f)]
        private float mSlideFrictionY = 0.2f;

        // Panel rect transform holder.
        // since the panel does not need to contain "JCS_SlidePanel" class, 
        // we will help them add the class during init time.
        public RectTransform[] slidePanels = null;

        private JCS_SlidePanel[] mSlidePanelsComponents = null;

        /* Setter & Getter */

        public RectTransform rectTransform { get { return this.mRectTransform; } }
        public float SlideFrictionX { get { return this.mSlideFrictionX; } set { this.mSlideFrictionX = value; } }
        public float SlideFrictionY { get { return this.mSlideFrictionY; } set { this.mSlideFrictionY = value; } }

        /* Functions */

        private void Awake()
        {
            this.mRectTransform = this.GetComponent<RectTransform>();

            mSlidePanelsComponents = new JCS_SlidePanel[slidePanels.Length];

            for (int index = 0; index < slidePanels.Length; ++index)
            {
                // add the component to the slide panel
                mSlidePanelsComponents[index] =
                    slidePanels[index].gameObject.AddComponent<JCS_SlidePanel>();

                // set friction
                mSlidePanelsComponents[index].SlideFrictionX = mSlideFrictionX;
                mSlidePanelsComponents[index].SlideFrictionY = mSlideFrictionY;
            }
        }

        /// <summary>
        /// Enable/Disable slide panels by ACT.
        /// </summary>
        /// <param name="act"></param>
        public void EnableSlidePanels(bool act)
        {
            foreach (JCS_SlidePanel sp in mSlidePanelsComponents)
                sp.enabled = act;
        }

        /// <summary>
        /// Move the position by delta position.
        /// </summary>
        /// <param name="deltaPos"></param>
        public void DeltaMove(Vector3 deltaPos)
        {
            foreach (JCS_SlidePanel sp in mSlidePanelsComponents)
                sp.transform.position -= deltaPos;
        }

        /// <summary>
        /// Difference between target position and current position.
        /// </summary>
        /// <returns></returns>
        public Vector3 PositionDiff()
        {
            // SOURCE: https://docs.unity3d.com/2018.1/Documentation/ScriptReference/UI.GraphicRaycaster.Raycast.html
            PointerEventData pointerEventData = null;
            Canvas canvas = JCS_Canvas.instance.GetCanvas();
            GraphicRaycaster raycaster = canvas.GetComponent<GraphicRaycaster>();

            // Set up the new Pointer Event
            pointerEventData = new PointerEventData(EventSystem.current);
            // Set the Pointer Event Position to that of the mouse position
            pointerEventData.position = Input.mousePosition;

            // Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            // Raycast using the Graphics Raycaster and mouse click position
            raycaster.Raycast(pointerEventData, results);

            JCS_SlidePanel sp = null;

            // For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                sp = result.gameObject.GetComponent<JCS_SlidePanel>();
                if (sp != null)
                    break;
            }

            if (sp != null)
            {
                Vector3 curPos = sp.transform.position;
                Vector3 targPos = sp.GetTargetPosition();
                return JCS_Mathf.AbsoluteValue(curPos - targPos);
            }

            return Vector3.zero;
        }

        /// <summary>
        /// Add Force to the panel.
        /// </summary>
        /// <param name="pos"></param>
        public void AddForce(Vector3 pos)
        {
            foreach (JCS_SlidePanel sp in mSlidePanelsComponents)
            {
                Vector3 tempPos = sp.GetTargetPosition() - pos;
                sp.SetTargetPosition(tempPos);
            }
        }

        /// <summary>
        /// Add Force to  the panel.
        /// </summary>
        /// <param name="force"></param>
        /// <param name="axis"></param>
        public void AddForce(float force, JCS_Axis axis)
        {
            if (force == 0.0f)
                return;

            Vector3 tempPos = Vector3.zero;

            switch (axis)
            {
                case JCS_Axis.AXIS_X:
                    tempPos.x = force;
                    break;
                case JCS_Axis.AXIS_Y:
                    tempPos.y = force;
                    break;
                case JCS_Axis.AXIS_Z:
                    tempPos.z = force;
                    break;
            }

            AddForce(tempPos);
        }
    }
}
