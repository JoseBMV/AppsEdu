using UnityEngine;

public class DestroyBelowY : MonoBehaviour
{
    public float yLimit = -10f;
    void Update()
    {
        if (transform.position.y < yLimit)
            Destroy(gameObject);
    }
}
