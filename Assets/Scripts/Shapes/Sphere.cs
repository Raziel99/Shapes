using System.Collections.Generic;
using UnityEngine;

public class Sphere : Shape
{
    [SerializeField]
    [Range(4, 20)]
    private int sectorsCount = 8;
    [SerializeField]
    [Min(0)]
    private float radius = 1f;

    public override void SetShape()
    {
        Vector3 startPoint = transform.position;
        float angle = 180f / sectorsCount;

        var verticies = new List<Vector3>()
        {
            startPoint + Vector3.up * radius
        };

        for (int i = 1; i < sectorsCount; i++)
        {
            float x = 270f + i * angle;

            while(x > 360f)
            {
                x -= 360f;
            }

            for (int j = 0; j < sectorsCount; j++)
            {
                float y = j * angle * 2f;

                Vector3 pointerVector = Quaternion.Euler(x, y, 0) * Vector3.forward;
                Vector3 point = startPoint + pointerVector * radius;
                verticies.Add(point);
            }
        }

        verticies.Add(startPoint - Vector3.up * radius);

        this.verticies = verticies.ToArray();

        var triangles = new List<int>();

        int verticiesCount = verticies.Count;

        for (int i = 0; i < sectorsCount - 2; i++)
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