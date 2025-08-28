using UnityEngine;

public class Player
{
    private IState state;

    public Player(IState state) { this.state = state; } // �ʱ� ���� ����
    public void setState(IState state) { this.state = state; } // ���� ��ȯ
    public void act() { state.Action(); } // ���� ���¿� ����
}