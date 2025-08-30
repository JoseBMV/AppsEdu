using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    [Header("Frecuencia")]
    public float firstDelay = 1f;   // primer spawn
    public float spawnRate = 1.5f;  // intervalo entre spawns

    [Header("Escala aleatoria")]
    [Tooltip("El mínimo y máximo tamaño que pueden tener las figuras")]
    public float minScale = 0.5f;   // tamaño mínimo
    public float maxScale = 2f;     // tamaño máximo

    void Start()
    {
        InvokeRepeating(nameof(SpawnOne), firstDelay, spawnRate);
    }

    void SpawnOne()
    {
        // Figura aleatoria
        int pick = Random.Range(0, 4);
        ShapeType st = (ShapeType)pick;

        GameObject go = CreatePrimitive(st);

        // Posición = donde está el Spawner
        go.transform.position = transform.position;

        // 👉 Escala aleatoria entre minScale y maxScale
        float s = Random.Range(minScale, maxScale);
        go.transform.localScale = Vector3.one * s;

        // Rigidbody para que caiga
        Rigidbody rb = go.AddComponent<Rigidbody>();
        rb.useGravity = true;
    }

    GameObject CreatePrimitive(ShapeType t)
    {
        PrimitiveType pt = PrimitiveType.Cube;
        switch (t)
        {
            case ShapeType.Cube: pt = PrimitiveType.Cube; break;
            case ShapeType.Sphere: pt = PrimitiveType.Sphere; break;
            case ShapeType.Capsule: pt = PrimitiveType.Capsule; break;
            case ShapeType.Cylinder: pt = PrimitiveType.Cylinder; break;
        }
        return GameObject.CreatePrimitive(pt);
    }
}
