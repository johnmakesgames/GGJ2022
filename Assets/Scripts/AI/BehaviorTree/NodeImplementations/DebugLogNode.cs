using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogNode : ActionNode
{
    public string DebugMessage = "NO_MESSAGE_SET";
    public override void OnEntered()
    {
        Debug.Log("STARTED");
    }
    
    public override void OnExit()
    {
        Debug.Log("ENDED");
    }

    public override NodeStates OnUpdate()
    {
        Debug.Log(DebugMessage);
        return NodeStates.Succeeded;
    }
}
