using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NorskaLib.UI.Widgets
{
	public class WidgetEvents : MonoBehaviour,
		IPointerDownHandler,
		IPointerUpHandler,
		IPointerClickHandler,
		IPointerEnterHandler,
		IPointerExitHandler,
		IDragHandler,
		IBeginDragHandler,
		IEndDragHandler
	{
        //[BoxGroup("Invokes"), LabelText("Begin Drag")]
        //public bool invokeBeginDrag;
        //[BoxGroup("Invokes"), LabelText("End Drag")]
        //public bool invokeEndDrag;
        //[BoxGroup("Invokes"), LabelText("Drag")]
        //public bool invokeDrag;
        //[BoxGroup("Invokes"), LabelText("Click")]
        //public bool invokeClick;
        //[BoxGroup("Invokes"), LabelText("Double Click")]
        //public bool invokeDoubleClick;
        //[BoxGroup("Invokes"), LabelText("Pointer Down")]
        //public bool invokePointerDown;
        //[BoxGroup("Invokes"), LabelText("Pointer Up")]
        //public bool invokePointerUp;
        //[BoxGroup("Invokes"), LabelText("Pointer Enter")]
        //public bool invokePointerEnter;
        //[BoxGroup("Invokes"), LabelText("Pointer Exit")]
        //public bool invokePointerExit;

        [Tooltip("Doble click limit in seconds")]
        public float doubleClickSpan = 0.125f;
        private float doubleClickTimer;
        private int clickCount = 0;

        #region MonoBehaviour

        void Update()
        {
            if (clickCount > 0)
            {
                doubleClickTimer += Time.deltaTime;
                if (doubleClickTimer >= doubleClickSpan)
                {
                    doubleClickTimer = 0;
                    clickCount = 0;
                }
            }
        }


        void OnDisable()
        {
            isDragged = false;
            pointerIsInside = false;
            pointerIsDown = false;
            doubleClickTimer = 0;
            clickCount = 0;
        }

        #endregion

        #region Callbacks

        [ShowInInspector, DisableIf("@true")]
        private bool isDragged;
        public bool IsDragged => isDragged;

        public event Action<PointerEventData> onBeginDrag;
        public void OnBeginDrag(PointerEventData eventData)
        {
            isDragged = true;
            onBeginDrag?.Invoke(eventData);
        }

        public event Action<PointerEventData> onDrag;
        public void OnDrag(PointerEventData eventData)
        {
            onDrag?.Invoke(eventData);
        }

        public event Action<PointerEventData> onEndDrag;
        public void OnEndDrag(PointerEventData eventData)
        {
            isDragged = false;
            onEndDrag?.Invoke(eventData);
        }

        [ShowInInspector, DisableIf("@true")]
        private bool pointerIsDown;
        public bool PointerIsDown => pointerIsDown;

        public event Action<PointerEventData> onClick;
        public event Action<PointerEventData> onDoubleClick;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (clickCount == 0)
                onClick?.Invoke(eventData);
            else
                onDoubleClick?.Invoke(eventData);
        }

        public event Action<PointerEventData> onPointerDown;
        public void OnPointerDown(PointerEventData eventData)
        {
            pointerIsDown = true;
            onPointerDown?.Invoke(eventData);
        }

        public event Action<PointerEventData> onPointerUp;
        public void OnPointerUp(PointerEventData eventData)
        {
            pointerIsDown = false;
            onPointerUp?.Invoke(eventData);
        }

        [ShowInInspector, DisableIf("@true")]
        private bool pointerIsInside;
        public bool PointerIsInside => pointerIsInside;

        public event Action<PointerEventData> onPointerEnter;
        public void OnPointerEnter(PointerEventData eventData)
        {
            pointerIsInside = true;
            onPointerEnter?.Invoke(eventData);
        }

        public event Action<PointerEventData> onPointerExit;
        public void OnPointerExit(PointerEventData eventData)
        {
            pointerIsInside = false;
            onPointerExit?.Invoke(eventData);
        }

        #endregion
    }
}