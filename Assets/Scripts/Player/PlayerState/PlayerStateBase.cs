using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateBase : IState
{
    protected PlayerController player;
    protected Dictionary<CardEnum, IState> cardTransitions
        = new Dictionary<CardEnum, IState>();

    protected Dictionary<InputType, IState> inputTransitions = new();
    public PlayerStateBase(PlayerController player)
    {
        this.player = player;
    }

    public virtual bool CardAction(CardEnum cardTag, CardData cardData)
    {
        if (cardTransitions.TryGetValue(cardTag, out var nextState))
        {
            player.stateManager.TransitionTo(nextState, cardData);

            return true;
        }
        return false;
    }
    public abstract void Initialize();
    public abstract void Enter();
    public abstract void Enter(CardData cardData);
    public abstract void Update();
    public abstract void Exit();

    public abstract void HandleInput(InputType input);
}