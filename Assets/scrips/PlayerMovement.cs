using UnityEngine;
using UnityEngine.InputSystem; // Nuevo Input System

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 8f;

    [Header("Límites del área (mundo)")]
    public float minX = -8f, maxX = 8f;
    public float minZ = -4.5f, maxZ = 4.5f;

    // input leído del action "Move" (x = izq/der, y = arriba/abajo)
    private Vector2 moveInput;

    void Update()
    {
        // Convertimos el Vector2 del input en dirección XZ
        Vector3 dir = new Vector3(moveInput.x, 0f, moveInput.y);

        // Movimiento en el mundo (no relativo a la rotación del player)
        transform.Translate(dir * speed * Time.deltaTime, Space.World);

        // Clampear dentro de límites
        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, minX, maxX);
        p.z = Mathf.Clamp(p.z, minZ, maxZ);
        transform.position = p;

        // (Opcional) Hacer que mire en la dirección de movimiento
        if (dir.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(dir, Vector3.up),
                0.15f
            );
        }
    }

    // Para "Send Messages" en Player Input
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); // teclado o stick izquierdo
    }
}
