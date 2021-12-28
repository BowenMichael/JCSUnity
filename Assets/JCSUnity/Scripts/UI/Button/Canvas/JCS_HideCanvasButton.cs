/**
 * $File: JCS_HideCanvasButton.cs $
 * $Date: 2021-12-28 23:46:09 $
 * $Revision: $
 * $Creator: Jen-Chieh Shen $
 * $Notice: See LICENSE.txt for modification and distribution information
 *	                 Copyright © 2021 by Shen, Jen-Chieh $
 */
using UnityEngine;

namespace JCSUnity
{
    /// <summary>
    /// Button to hide canvas so it's invisibile on the screen.
    /// </summary>
    public class JCS_HideCanvasButton : JCS_Button
    {
        /* Variables */

        [Header("** Runtime Variables (JCS_HideCanvasButton) **")]

        [Tooltip("Target canvas to hide.")]
        public JCS_Canvas[] canvas = null;

        /* Setter & Getter */

        /* Functions */

        public override void OnClick()
        {
            JCS_UIUtil.HideCanvas(canvas);
        }
    }
}
