using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField]
    int _hp;
    [SerializeField]
    int _maxhp;
    [SerializeField]
    int _attack;
    [SerializeField]
    int _moveSpeed;


    public int HP { get { return _hp; } set { _hp = value; } }
    public int Maxhp{get { return _maxhp; }set { _maxhp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

}
