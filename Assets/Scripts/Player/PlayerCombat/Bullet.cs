using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    private int damage;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }
    public void Initialize(GunCardData data, Vector2 dir, Collider2D ownerCollider)
    {
        damage = data.Damage;
        spriteRenderer.sprite = data.bulletSprite;

        rigidBody.linearVelocity = dir * data.bulletSpeed;
        Destroy(gameObject, data.bulletLifetime);

        // 발사자와 충돌 무시
        Collider2D bulletCollider = GetComponent<Collider2D>();
        if (bulletCollider != null && ownerCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, ownerCollider);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IAttack_Interface target = other.GetComponent<IAttack_Interface>();
        if (target != null)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
