using UnityEngine;

public interface IState
{
    public void Enter() { }
    public void Update() { }
    public void Action() { }
    public void Exit() { }

};