using UnityEngine;

public class Player
{
    private IState state;

    public Player(IState state) { this.state = state; } // 초기 상태 주입
    public void setState(IState state) { this.state = state; } // 상태 전환
    public void act() { state.Action(); } // 현재 상태에 위임
}