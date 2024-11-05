using UnityEngine;

public class DragginArrow : MonoBehaviour
{
    [SerializeField]
    private GameObject render;
    [SerializeField]
    private Renderer bounds;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private bool isDragging = false;
    private float maxArrowWidth;

    void Start()
    {
        maxArrowWidth = bounds.bounds.size.x;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 position = startPoint;
            position.z = 0;
            transform.position = position;

            isDragging = true;
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            UpdateArrow();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            HideArrow();
        }
    }

    void UpdateArrow()
    {
        Vector3 direction = endPoint - startPoint;
        float distance = direction.magnitude;
        distance = Mathf.Clamp(distance, 0, maxArrowWidth * 1.5f);
        render.transform.localScale = Vector3.one * (distance / maxArrowWidth);

        Vector3 rotationVector = direction.normalized * -1;
        float angle = Mathf.Atan2(rotationVector.y, rotationVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        render.SetActive(true);
    }

    void HideArrow()
    {
        render.SetActive(false);
    }
}
