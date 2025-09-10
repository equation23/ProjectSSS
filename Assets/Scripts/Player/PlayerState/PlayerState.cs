using UnityEngine;

public interface IState
{
    public void Initialize();
    public void Enter();
    public void Update();
    public bool CardAction(CardEnum Cardtag);
    public void Exit();

};