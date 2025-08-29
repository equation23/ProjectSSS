using UnityEngine;

public class Player_Idle : IState
{
    private PlayerController player;

    public Player_Idle(PlayerController player) {  this.player = player; }
    public void Enter() 
    {
        //Debug.Log("Move !!!");
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.stateManager.TransitionTo(player.stateManager.jumpState);
        }
    }
    public void Action() 
    {
    }
    public void Exit() 
    { 
    }
}
