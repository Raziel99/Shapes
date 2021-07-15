using UnityEngine;

public static class ShapeFactory<T> where T : Shape
{
    public static T CreateShape()
    {
        GameObject go = new GameObject(typeof(T).Name);

        T shape = go.AddComponent<T>();
        shape.SetShape();

        return shape;
    }
}
