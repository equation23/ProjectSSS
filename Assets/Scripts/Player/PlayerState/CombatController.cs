using UnityEngine;

[System.Serializable]
public class CombatController
{
    public Combat_Sword_Collider swordCollider;
    public Transform firePoint;

    private BoxCollider2D boxCollider;

    public void Initialize(BoxCollider2D collider)
    {
        boxCollider = collider;
    }


    public void ShootBullet(GunCardData data, bool facingRight)
    {
        if (data == null || data.bulletPrefab == null || firePoint == null) return;

        GameObject bulletObj = Object.Instantiate(data.bulletPrefab, firePoint.position, Quaternion.identity);
        Vector2 dir = facingRight ? Vector2.right : Vector2.left;

        bulletObj.GetComponent<Bullet>().Initialize(data, dir, boxCollider);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("PlayerDamaged " + damage);
    }
}
