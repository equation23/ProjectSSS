using System.Threading;
using UnityEngine;
using System.Collections;

public class Combat_Sword_Collider :MonoBehaviour
{
    public Collider2D attackCollider; // AttackPoint에 붙인 Collider2D
    private int Damage = 0;
    private void Awake()
    {
        attackCollider.enabled = false;
    }
    void Update()
    {
     
    }

    public void CollisionStart(int damage, Collider2D ownerCollider)
    {
        Damage = damage;

        // 생성자와 충돌 무시
        Collider2D bulletCollider = GetComponent<Collider2D>();
        if (bulletCollider != null && ownerCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, ownerCollider);
        }

        StartCoroutine(Attack());
  
    }
    IEnumerator Attack()
    {
        attackCollider.enabled = true;
        yield return new WaitForSeconds(0.2f); // 공격 판정 유지 시간
        attackCollider.enabled = false;
        Damage = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IAttack_Interface target = other.GetComponent<IAttack_Interface>();
        if (target != null)
        {
            target.TakeDamage(Damage);
        }
    }

    private void OnDrawGizmos()
    {
        if (!attackCollider || !attackCollider.enabled) return;
        Gizmos.color = Color.red;
        Vector2 boxSize = new Vector2(attackCollider.bounds.size.x, attackCollider.bounds.size.y);
        Vector2 origin = new Vector2(attackCollider.bounds.center.x, attackCollider.bounds.center.y);
        Gizmos.DrawWireCube(origin, boxSize);
    }

}
