using UnityEngine;
using System.Collections.Generic;

public class Capsule : Shape
{
    [SerializeField]
    [Range(4, 20)]
    private int sectorsCount = 8;
    [SerializeField]
    [Min(0)]
    private float height = 2f;
    [SerializeField]
    [Min(0)]
    private float radius = 1f;

    public override void SetShape()
    {
        Vector3 startPoint = transform.position + Vector3.up * (height - radius);
        float angle = 30f;

        var verticies = new List<Vector3>()
        {
            startPoint + Vector3.up * radius
        };

        for (int i = 1; i < 3; i++)
        {
            float x = 270f + i * angle;

            while (x > 360f)
            {
                x -= 360f;
            }

            for (int j = 0; j < sectorsCount; j++)
            {
                float y = j * (360f / sectorsCount);

                Vector3 pointerVector = Quaternion.Euler(x, y, 0) * Vector3.forward;
                Vector3 point = startPoint + pointerVector * radius;

                verticies.Add(point);
            }
        }

        startPoint = transform.position - Vector3.up * (height - radius);
        var bottomVerticies = new List<Vector3>();

        for (int i = 1; i < 3; i++)
        {
            float x = 90f - i * angle;

            while (x > 360f)
            {
                x -= 360f;
            }

            for (int j = 0; j < sectorsCount; j++)
            {
                float y = (sectorsCount - j - 1) * (360f / sectorsCount);

                Vector3 pointerVector = Quaternion.Euler(x, y, 0) * Vector3.forward;
                Vector3 point = startPoint + pointerVector * radius;

                bottomVerticies.Add(point);
            }
        }

        bottomVerticies.Reverse();
        verticies.AddRange(bottomVerticies);
        verticies.Add(startPoint - Vector3.up * radius);

        this.verticies = verticies.ToArray();

        int verticiesCount = verticies.Count;

        var triangles = new List<int>();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < sectorsCount - 1; j++)
            {
                triangles.Add(i * sectorsCount + j + 1);
                triangles.Add(i * sectorsCount + j + 1 + sectorsCount);
                triangles.Add(i * sectorsCount + j + 1 + sectorsCount + 1);
                triangles.Add(i * sectorsCount + j + 1);
                triangles.Add(i * sectorsCount + j + 1 + sectorsCount + 1);
                triangles.Add(i * sectorsCount + j + 1 + 1);
            }

            triangles.Add(i * sectorsCount + 1 + sectorsCount - 1);
            triangles.Add(i * sectorsCount + 1 + sectorsCount + sectorsCount - 1);
            triangles.Add(i * sectorsCount + 1 + sectorsCount);
            triangles.Add(i * sectorsCount + 1 + sectorsCount - 1);
            triangles.Add(i * sectorsCount + 1 + sectorsCount);
            triangles.Add(i * sectorsCount + 1);
        }

        for (int i = 0; i < sectorsCount - 1; i++)
        {
            triangles.Add(0);
            triangles.Add(i + 1);
            triangles.Add(i + 2);

            triangles.Add(verticiesCount - 1);
            triangles.Add(verticiesCount - 1 - i - 1);
            triangles.Add(verticiesCount - 1 - i - 2);
        }

        triangles.Add(0);
        triangles.Add(sectorsCount);
        triangles.Add(1);

        triangles.Add(verticiesCount - 1);
        triangles.Add(verticiesCount - 1 - sectorsCount);
        triangles.Add(verticiesCount - 1 - 1);

        this.triangles = triangles.ToArray();

        base.SetShape();
    }
}