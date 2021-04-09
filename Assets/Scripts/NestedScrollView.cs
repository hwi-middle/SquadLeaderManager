using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NestedScrollView : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{    
    // Event Filtering
    bool shouldSendEvent = false;
    Vector3 oldPos = Vector3.zero;

    bool isCheckEnd = false;
    ScrollRect parentScrollRect = null;

    // event delivery
    public void OnBeginDrag(PointerEventData eventData)
    {
        isCheckEnd = false;
        if (shouldSendEvent)
        {
            parentScrollRect.OnBeginDrag(eventData);
        }
    }
    // event delivery
    public void OnDrag(PointerEventData eventData)
    {
        if (shouldSendEvent)
        {
            parentScrollRect.OnDrag(eventData);
        }
        if (isCheckEnd)
        {
            return;
        }
        isCheckEnd = true;
        oldPos = Input.mousePosition;
        StartCoroutine(Check());
    }
    // event delivery
    public void OnEndDrag(PointerEventData eventData)
    {
        if (shouldSendEvent)
        {
            parentScrollRect.OnEndDrag(eventData);
        }
    }
    void Start()
    {
        parentScrollRect = transform.parent.parent.parent.GetComponent<ScrollRect>();
    }

    IEnumerator Check()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        Vector3 temp = Input.mousePosition - oldPos;
        shouldSendEvent = temp.x * temp.x < temp.y * temp.y;
        GetComponent<ScrollRect>().enabled = !shouldSendEvent;
    }
}