using System.Threading;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    void Start()
    {
        Player player = new Player(new Player_Idle());
        player.act();                   // �̵� !!!
        player.setState(new Player_Jump());
        player.act();                   // ���� !!!
    }
}
