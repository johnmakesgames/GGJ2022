using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class INode : ScriptableObject
{
    public enum NodeStates
    {
        Running,
        Failed,
        Succeeded
    }

    public NodeStates currentState = NodeStates.Running;
    public bool running = false;
    public string Guid;
    public GameObject parent;

    public NodeStates Update()
    {
        if (!running)
        {
            OnEntered();
            running = true;
        }

        currentState = OnUpdate();

        if (currentState == NodeStates.Succeeded || currentState == NodeStates.Failed)
        {
            OnExit();
            running = false;
        }

        return currentState;
    }

    public abstract void OnEntered();
    public abstract NodeStates OnUpdate();
    public abstract void OnExit();
}
