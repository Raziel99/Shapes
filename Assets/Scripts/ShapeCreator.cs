using UnityEditor;

public static class ShapeCreator
{
    [MenuItem(itemName: "Parallelepiped", menuItem = "GameObject/Objects/Parallelepiped _b")]
    public static void CreateParallelepiped()
    {
        ShapeFactory<Parallelepiped>.CreateShape();
    }
    [MenuItem(itemName: "Prysm", menuItem = "GameObject/Objects/Prysm _j")]
    public static void CreatePrysm()
    {
        ShapeFactory<Prysm>.CreateShape();
    }
    [MenuItem(itemName: "Sphere", menuItem = "GameObject/Objects/Sphere _s")]
    public static void CreateSphere()
    {
        ShapeFactory<Sphere>.CreateShape();
    }
    [MenuItem(itemName: "Capsule", menuItem = "GameObject/Objects/Capsule _c")]
    public static void CreateCapsule()
    {
        ShapeFactory<Capsule>.CreateShape();
    }
}
