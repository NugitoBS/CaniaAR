using UnityEngine;

public class TouchInteraction : MonoBehaviour
{
    private Vector3 initialScale;
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    private float rotationSpeed = 0.2f;
    private float scaleSpeed = 0.01f;

    void Start()
    {
        initialScale = transform.localScale;
        initialRotation = transform.localRotation;
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // ===== Rotate =====
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotY = touch.deltaPosition.x * rotationSpeed;
                transform.Rotate(0, -rotY, 0, Space.World);
            }
        }

        // ===== Zoom in & out =====
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 prevTouchZeroPos = touchZero.position - touchZero.deltaPosition;
            Vector2 prevTouchOnePos = touchOne.position - touchOne.deltaPosition;
            float prevMagnitude = (prevTouchZeroPos - prevTouchOnePos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;
            Vector3 newScale = transform.localScale + Vector3.one * difference * scaleSpeed;
            newScale = ClampScale(newScale, 0.1f, 3f); // batasi skala
            transform.localScale = newScale;
        }
    }

    Vector3 ClampScale(Vector3 scale, float min, float max)
    {
        scale.x = Mathf.Clamp(scale.x, min, max);
        scale.y = Mathf.Clamp(scale.y, min, max);
        scale.z = Mathf.Clamp(scale.z, min, max);
        return scale;
    }

    // ===== To Reset Position =====
    public void ResetTransform()
    {
        transform.localScale = initialScale;
        transform.localRotation = initialRotation;
        transform.localPosition = initialPosition;
    }
}