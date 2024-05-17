using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Vector3 offset;
    Vector3 worldPos;
    public Canvas canvas;
    public void OnBeginDrag(PointerEventData eventData)
    {
        worldPos = eventData.position;
        switch (canvas.renderMode)
        {
            case RenderMode.ScreenSpaceOverlay:
                break;
            case RenderMode.ScreenSpaceCamera:
            case RenderMode.WorldSpace:
                worldPos = canvas.worldCamera.ScreenToWorldPoint(new Vector3(worldPos.x, worldPos.y, transform.position.z));
                break;
            default:
                break;
        }
        offset = worldPos - transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        worldPos = eventData.position;
        switch (canvas.renderMode)
        {
            case RenderMode.ScreenSpaceOverlay:
                break;
            case RenderMode.ScreenSpaceCamera:
            case RenderMode.WorldSpace:
                worldPos = canvas.worldCamera.ScreenToWorldPoint(new Vector3(worldPos.x, worldPos.y, transform.position.z));
                break;
            default:
                break;
        }
        transform.position = worldPos - offset;
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.parent.GetComponent<Canvas>();
    }
}
