using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableSnapPanel : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform dragHandle; // Assign the top bar here in Inspector
    public float snapThreshold = 100f; // Distance threshold for snapping
    public float snapSpeed = 10f;

    private RectTransform panelRect;
    private Vector2 dragOffset;
    private Vector2 fullScreenPos;
    private Vector2 collapsedPos;
    private bool isDragging = false;
    private bool isCollapsed = false;

    void Start()
    {
        panelRect = GetComponent<RectTransform>();

        fullScreenPos = Vector2.zero; // Full screen = anchored at (0,0)
        collapsedPos = new Vector2(0, -Screen.height + 100); // Adjust 100 as height of handle

        // Snap to full on start
        panelRect.anchoredPosition = fullScreenPos;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsPointerOverDragHandle(eventData)) return;
        isDragging = true;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRect, eventData.position, eventData.pressEventCamera, out dragOffset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        Vector2 localPointerPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRect, eventData.position, eventData.pressEventCamera, out localPointerPos))
        {
            Vector2 offset = localPointerPos - dragOffset;
            panelRect.anchoredPosition = new Vector2(0, offset.y);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        float distanceToCollapsed = Vector2.Distance(panelRect.anchoredPosition, collapsedPos);
        float distanceToFull = Vector2.Distance(panelRect.anchoredPosition, fullScreenPos);

        if (distanceToCollapsed < snapThreshold)
        {
            isCollapsed = true;
        }
        else
        {
            isCollapsed = false;
        }

        // Snap with smooth animation
        StopAllCoroutines();
        StartCoroutine(SmoothSnap(isCollapsed ? collapsedPos : fullScreenPos));
    }

    private System.Collections.IEnumerator SmoothSnap(Vector2 targetPos)
    {
        while (Vector2.Distance(panelRect.anchoredPosition, targetPos) > 1f)
        {
            panelRect.anchoredPosition = Vector2.Lerp(panelRect.anchoredPosition, targetPos, Time.deltaTime * snapSpeed);
            yield return null;
        }
        panelRect.anchoredPosition = targetPos;
    }

    private bool IsPointerOverDragHandle(PointerEventData eventData)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(dragHandle, eventData.position, eventData.enterEventCamera);
    }
}
