using UnityEngine;

public class PlayerHitDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if (collectable != null)
            collectable.OnCollect(transform.position);
    }
}
