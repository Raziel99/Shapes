using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    protected MeshRenderer meshRenderer;
    [HideInInspector]
    [SerializeField]
    protected MeshFilter meshFilter;
    [HideInInspector]
    [SerializeField]
    protected Vector3[] verticies;
    [HideInInspector]
    [SerializeField]
    protected int[] triangles;
    [SerializeField]
    private Color color = Color.white;

    private void OnValidate()
    {
        SetShape();
    }
    public virtual void SetShape()
    {
        if (meshRenderer == null) meshRenderer = gameObject.AddComponent<MeshRenderer>();
        if (meshFilter == null) meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh()
        {
            vertices = verticies,
            triangles = triangles
        };

        if (meshFilter.sharedMesh != null)
        {
            meshFilter.sharedMesh.Clear();
        }

        meshFilter.sharedMesh = mesh;
        Material material = new Material(Shader.Find("Unlit/Color"));
        material.SetColor("_Color", color);
        meshRenderer.material = material;
        meshFilter.sharedMesh.RecalculateNormals();
    }
}
