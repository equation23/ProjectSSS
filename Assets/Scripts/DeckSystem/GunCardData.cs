using UnityEngine;

[CreateAssetMenu(menuName = "Card/GunCardData", fileName = "NewGunCardData")]
public class GunCardData : CardData
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float bulletLifetime;
    public Sprite bulletSprite;
}