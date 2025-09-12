using UnityEngine;
public enum InputType { Jump, Dash }
public interface IState
{

    public void Initialize();
    public void Enter();
    public void Enter(CardData cardData);
    public void Update();
    public void Exit();
    public bool CardAction(CardEnum Cardtag, CardData cardData);

    public void HandleInput(InputType input);
};