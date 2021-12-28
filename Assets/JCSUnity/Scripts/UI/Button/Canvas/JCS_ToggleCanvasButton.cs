/**
 * $File: JCS_ToggleCanvasButton.cs $
 * $Date: 2021-12-29 00:03:03 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *	                 Copyright © 2021 by Shen, Jen-Chieh $
 */
using UnityEngine;

namespace JCSUnity
{
    /// <summary>
    /// Button that toggles canvas' visibility.
    /// </summary>
    public class JCS_ToggleCanvasButton : JCS_ToggleButton
    {
        /* Variables */

        [Header("** Runtime Variables (JCS_HideCanvasButton) **")]

        [Tooltip("Target canvas to hide.")]
        public JCS_Canvas[] canvas = null;

        /* Setter & Getter */

        /* Functions */

        protected virtual void Start()
        {
            onActive += Show;
            onDeactive += Hide;
        }

        private void Show()
        {
            JCS_UIUtil.ShowCanvas(canvas);
        }

        private void Hide()
        {
            JCS_UIUtil.HideCanvas(canvas);
        }
    }
}
