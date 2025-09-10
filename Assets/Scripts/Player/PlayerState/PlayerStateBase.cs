using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateBase : IState
{
    protected PlayerController player;
    protected Dictionary<string, IState> cardTransitions
        = new Dictionary<string, IState>();

    public PlayerStateBase(PlayerController player)
    {
        this.player = player;
    }

    public virtual void CardAction(string cardName)
    {
        if (cardTransitions.TryGetValue(cardName, out var nextState))
        {
            player.stateManager.TransitionTo(nextState);
        }
    }
    public abstract void Initialize();
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}