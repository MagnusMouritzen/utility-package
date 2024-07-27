using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OK.Utility {
    public class CollisionTransfer : MonoBehaviour, IPointerClickHandler
    {
        public Action ClickAction;

        public void OnPointerClick(PointerEventData eventData)
        {
            ClickAction?.Invoke();
        }
    }
}
