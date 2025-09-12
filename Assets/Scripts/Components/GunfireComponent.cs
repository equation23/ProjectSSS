using UnityEngine;

public class GunfireComponent : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet 프리팹
    public Transform firePoint;     // 총구 위치(자식 오브젝트)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // 예: F키로 발사
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // 바라보는 방향 구하기
        Vector2 dir = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        bullet.GetComponent<Bullet>().SetDirection(dir);
    }
}
