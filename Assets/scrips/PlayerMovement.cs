using UnityEngine;
using UnityEngine.InputSystem; // Nuevo Input System

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float limiteX = 8f;

    private float moveInput;

    void Update()
    {
        transform.Translate(moveInput * speed * Time.deltaTime, 0f, 0f);

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limiteX, limiteX);
        transform.position = pos;
    }

    // 👇 Firma correcta para "Send Messages"
    public void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        moveInput = v.x; // teclado o stick izquierdo del control
    }
}
