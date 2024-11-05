using UnityEngine;

public class DragginArrow : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;

    [SerializeField]
    private GameObject arrowRender;

    [SerializeField]
    private Renderer arrowBounds;

    [SerializeField]
    private Rigidbody2D objectToThrow;

    [SerializeField]
    private float force = 150;

    private Vector3 startPoint;
    private Vector3 endPoint;
    private bool isDragging = false;
    private float maxArrowWidth;

    void Start()
    {
        maxArrowWidth = arrowBounds.bounds.size.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
            arrowRender.SetActive(true);

        }

        if (isDragging && Input.GetMouseButton(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateArrow();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            arrowRender.SetActive(false);
            ThrowObject();
        }
    }

    void UpdateArrow()
    {
        Vector3 direction = startPoint - endPoint;
        ApplyArrowScale(direction);
        ApplyArrowRotation(direction);
    }

    void ApplyArrowScale(Vector3 direction)
    {
        float distance = direction.magnitude;
        distance = Mathf.Clamp(distance, 0, maxArrowWidth);
        arrowRender.transform.localScale = Vector3.one * (distance / maxArrowWidth);
    }

    void ApplyArrowRotation(Vector3 direction)
    {
        Vector3 rotationVector = direction.normalized * -1;
        float angle = Mathf.Atan2(rotationVector.y, rotationVector.x) * Mathf.Rad2Deg;
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void ThrowObject()
    {
        Vector3 direction = startPoint - endPoint;
        objectToThrow.gravityScale = 1;
        objectToThrow.AddForce(direction * force);
    }
}
