using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITest : MonoBehaviour //https://forum.unity.com/threads/how-to-detect-if-mouse-is-over-ui.1025533/
{
    public bool IsOverPannel;
    int UILayer;

    private void Start()
    {
        UILayer = LayerMask.NameToLayer("Pannel");
    }

    private void Update()
    {
        print(IsPointerOverUIElement() ? "Over UI" : "Not over UI");

    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    public bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }


    //Returns 'true' if we touched or hovering on Unity UI element.
    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == UILayer)
            {
                IsOverPannel = true;
                return true;
            }
                
        }
        IsOverPannel = false;
        return false;
    }


    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }

}