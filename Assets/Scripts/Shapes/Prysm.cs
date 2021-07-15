using System.Collections.Generic;
using UnityEngine;

public class Prysm : Shape
{
    [SerializeField]
    [Range(3, 10)]
    private int baseAnglesCount = 3;
    [SerializeField]
    [Min(0)]
    private float radius = 1f;
    [SerializeField]
    [Min(0)]
    private float height = 1f;

    public override void SetShape()
    {
        Vector3 startPoint = transform.position - Vector3.up * height / 2f;

        float angle = 360f / baseAnglesCount;

        var verticies = new List<Vector3>();

        for (int i = 0; i < baseAnglesCount; i++)
        {
            Vector3 point = startPoint + Quaternion.Euler(i * angle * Vector3.up) * Vector3.forward * radius;
            verticies.Add(point);
        }

        for (int i = 0; i < baseAnglesCount; i++)
        {
            Vector3 point = verticies[i];
            point.y += height;
            verticies.Add(point);
        }

        this.verticies = verticies.ToArray();

        var triangles = new List<int>();

        for (int i = 0; i < baseAnglesCount - 1; i++)
        {
            triangles.Add(baseAnglesCount + i + 1);
            triangles.Add(baseAnglesCount + i);
            triangles.Add(i);
            triangles.Add(i + 1);
            triangles.Add(baseAnglesCount + i + 1);
            triangles.Add(i);
        }

        triangles.Add(baseAnglesCount);
        triangles.Add(baseAnglesCount + baseAnglesCount - 1);
        triangles.Add(baseAnglesCount - 1);
        triangles.Add(0);
        triangles.Add(baseAnglesCount);
        triangles.Add(baseAnglesCount - 1);

        for (int i = 1; i < baseAnglesCount - 1; i++)
        {
            triangles.Add(i + 1);
            triangles.Add(i);
            triangles.Add(0);
            triangles.Add(baseAnglesCount + i);
            triangles.Add(baseAnglesCount + i + 1);
            triangles.Add(baseAnglesCount);
        }

        this.triangles = triangles.ToArray();

        base.SetShape();
    }
}