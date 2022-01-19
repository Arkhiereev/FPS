using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick_ : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    internal Vector2 input = Vector2.zero;
    
    private Canvas canvas;
    private Camera cam;

    private float HandleRange
    {
        get { return handleRange; }
        set { handleRange = Mathf.Abs(value); }
    }

    private float DeadZone
    {
        get { return deadZone; }
        set { deadZone = Mathf.Abs(value); }
    }

    [SerializeField] private float handleRange = 1;
    [SerializeField] private float deadZone = 0;

    [SerializeField] private RectTransform background = null;
    [SerializeField] private RectTransform handle = null;

    private void Start()
    {
        HandleRange = handleRange;
        DeadZone = deadZone;
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
            Debug.LogError("The Joystick is not placed inside a canvas");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        cam = null;
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            cam = canvas.worldCamera;

        Vector2 position = RectTransformUtility.WorldToScreenPoint(cam, background.position);
        Vector2 radius = background.sizeDelta / 2;
        input = (eventData.position - position) / (radius * canvas.scaleFactor);
        HandleInput(input.magnitude, input.normalized, radius, cam);
        handle.anchoredPosition = input * radius * handleRange;
    }

    protected void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > deadZone)
        {
            if (magnitude > 1)
                input = normalised;
        }
        else
            input = Vector2.zero;
    }
}