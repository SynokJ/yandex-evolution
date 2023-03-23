using UnityEngine;

public class SpawnableBullet : Spawnable
{
    [Header("Bullet Components:")]
    [SerializeField] private BulletSO _bulletSO;
    [SerializeField] private Rigidbody2D _rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHitableEntity hitable = collision.GetComponent<IHitableEntity>();
        if (hitable != null)
        {
            hitable.OnRecieveDamage(_bulletSO.damage);
            OnHideSpawnable();
        }
    }

    public void OnShotBullet(Vector2 targetPos)
    {
        transform.position = Vector2.zero;

        _rb.velocity = Vector2.zero;
        _rb.velocity = (targetPos - (Vector2)transform.position).normalized * _bulletSO.speed;
    }
}
