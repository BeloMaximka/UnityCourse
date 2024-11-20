using UnityEngine;

public class DragAndThrow : MonoBehaviour
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
    private readonly float threshold = 0.1f;

    void Start()
    {
        maxArrowWidth = arrowBounds.bounds.size.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPoint = startPoint;
            isDragging = true;
            arrowRender.SetActive(true);
            ApplyArrowScale(0);
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
        Vector3 direction = endPoint - startPoint;
        if (direction.magnitude < threshold)
        {
            return;
        }

        ApplyArrowRotation(direction);

        float scale = Mathf.Clamp(direction.magnitude, 0, maxArrowWidth) / maxArrowWidth;
        ApplyArrowScale(scale);
        ApplyArrowColor(scale);
    }

    void ApplyArrowScale(float scale)
    {
        arrowRender.transform.localScale = Vector3.one * scale;
    }

    void ApplyArrowColor(float scale)
    {
        SpriteRenderer[] sprites = arrowRender.GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = Color.Lerp(Color.green, Color.red, scale);
        }
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
        if (direction.magnitude < threshold)
        {
            return;
        }

        objectToThrow.gravityScale = 1;
        objectToThrow.AddForce(direction * force);
    }
}
