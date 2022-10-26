using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour
{
    LineRenderer lr;
    [SerializeField] int lrPositionCount = 2;
    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lr.positionCount = lrPositionCount;
        Vector3[] points = new Vector3[lrPositionCount];
        points[0] = startPoint;
        points[1] = endPoint;
        lr.SetPositions(points);
    }
    public void EndLine()
    {
        lr.positionCount = 0;
    }
}
