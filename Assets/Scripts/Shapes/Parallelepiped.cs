using System.Collections.Generic;
using UnityEngine;

public class Parallelepiped : Shape
{
    [SerializeField]
    [Min(0)]
    private float length = 1f;
    [SerializeField]
    [Min(0)]
    private float height = 1f;
    [SerializeField]
    [Min(0)]
    private float width = 1f;

    public override void SetShape()
    {
        verticies = new Vector3[]
        {
            transform.position + new Vector3(-width / 2f, -height / 2f, -length / 2f),
            transform.position + new Vector3(-width / 2f, -height / 2f, +length / 2f),
            transform.position + new Vector3(+width / 2f, -height / 2f, +length / 2f),
            transform.position + new Vector3(+width / 2f, -height / 2f, -length / 2f),
            transform.position + new Vector3(-width / 2f, +height / 2f, -length / 2f),
            transform.position + new Vector3(-width / 2f, +height / 2f, +length / 2f),
            transform.position + new Vector3(+width / 2f, +height / 2f, +length / 2f),
            transform.position + new Vector3(+width / 2f, +height / 2f, -length / 2f)
        };
        triangles = new int[]
        {
            0, 2, 1,
            3, 2, 0,
            0, 4, 7,
            7, 3, 0,
            0, 1, 4,
            5, 4, 1,
            6, 5, 1,
            1, 2, 6,
            7, 6, 3,
            2, 3, 6,
            4, 5, 6,
            4, 6, 7
        };

        base.SetShape();
    }
}
