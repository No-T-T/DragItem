using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    Vector3 offset;
    Vector2 worldPos;
    Vector3 newPos;
    Canvas canvas;
    bool inTrans;
    public void OnBeginDrag(PointerEventData eventData)
    {
        switch (canvas.renderMode)
        {
            case RenderMode.ScreenSpaceOverlay:
                worldPos = eventData.position;
                inTrans = true;
                break;
            case RenderMode.ScreenSpaceCamera:
            case RenderMode.WorldSpace:
                inTrans = RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(),
                  eventData.position, canvas.worldCamera, out worldPos);
                break;
            default:
                break;
        }
        if (!inTrans) return;
        newPos = worldPos;
        newPos.z = transform.localPosition.z;
        offset = newPos - transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        switch (canvas.renderMode)
        {
            case RenderMode.ScreenSpaceOverlay:
                worldPos = eventData.position;
                inTrans = true;
                break;
            case RenderMode.ScreenSpaceCamera:
            case RenderMode.WorldSpace:
                inTrans = RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(),
                  eventData.position, canvas.worldCamera, out worldPos);
                break;
            default:
                break;
        }
        if (!inTrans) return;
        newPos = worldPos;
        newPos.z = transform.localPosition.z;
        transform.localPosition = newPos - offset;
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.parent.GetComponent<Canvas>();
    }
}
