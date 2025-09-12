using UnityEngine;

public class Monster : MonoBehaviour, IAttack_Interface
{
    public Stat stat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        stat.HP-=damage;
        Debug.Log("Monster HP = " + stat.HP);
    }

}
