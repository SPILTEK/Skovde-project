using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathingShapeTask : MonoBehaviour
{
    public GameObject shapePrefab; // Prefab for the shape to trace
    public Transform spawnPoint; // Where the shape appears
    public bool showShape = false; // Set true to trigger the shape
    private GameObject currentShape;
    private LineRenderer lineRenderer;
    private LineRenderer playerLineRenderer;
    private List<Vector2> drawnPoints = new List<Vector2>();
    private List<Vector2> shapePoints = new List<Vector2>();
    private int currentPointIndex = 0;

    void Update()
    {
        if (showShape && currentShape == null)
        {
            SpawnShape();
        }

        if (currentShape != null)
        {
            HandleDrawing();
        }
    }

    void SpawnShape()
    {
        currentShape = Instantiate(shapePrefab, spawnPoint.position, Quaternion.identity);
        lineRenderer = currentShape.GetComponent<LineRenderer>();
        ExtractShapePoints();
        CreatePlayerLineRenderer();
    }

    void ExtractShapePoints()
    {
        shapePoints.Clear();
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            shapePoints.Add(lineRenderer.GetPosition(i));
        }
        // Ensure the shape is closed by adding the first point to the end
        if (shapePoints.Count > 0)
        {
            shapePoints.Add(shapePoints[0]);
        }
        currentPointIndex = 0;
    }

    void CreatePlayerLineRenderer()
    {
        GameObject playerLine = new GameObject("PlayerLine");
        playerLineRenderer = playerLine.AddComponent<LineRenderer>();
        playerLineRenderer.startWidth = 0.1f;
        playerLineRenderer.endWidth = 0.1f;
        playerLineRenderer.positionCount = 0;
        playerLineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        playerLineRenderer.startColor = Color.red;
        playerLineRenderer.endColor = Color.red;
    }

    void HandleDrawing()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (currentPointIndex < shapePoints.Count && Vector2.Distance(touchPos, shapePoints[currentPointIndex]) < 0.5f)
            {
                if (!drawnPoints.Contains(shapePoints[currentPointIndex]))
                {
                    drawnPoints.Add(shapePoints[currentPointIndex]);
                    playerLineRenderer.positionCount = drawnPoints.Count;
                    playerLineRenderer.SetPosition(drawnPoints.Count - 1, shapePoints[currentPointIndex]);
                    currentPointIndex++;
                }
            }
        }

        if (currentPointIndex >= shapePoints.Count - 1 && drawnPoints.Count > 1 && Vector2.Distance(drawnPoints[0], drawnPoints[drawnPoints.Count - 1]) < 0.5f)
        {
            CompleteTask();
        }
    }

    void CompleteTask()
    {
        Destroy(currentShape);
        Destroy(playerLineRenderer.gameObject);
        drawnPoints.Clear();
        showShape = false;
    }
}
