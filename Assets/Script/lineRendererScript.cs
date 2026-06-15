using UnityEngine;

public class lineRendererScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] int count;
    private Vector3[] points;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.startColor = lineRenderer.endColor = Random.ColorHSV();
        lineRenderer.positionCount = count;
        points = new Vector3[count];

        for(int i = 0; i < count; i++)
        {
            points[i] = transform.position;
        }
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < count - 1; i++)
        {
            points[i] = points[i + 1];
        }
        points[count - 1] = transform.position;
        lineRenderer.SetPositions(points);
    }
}
