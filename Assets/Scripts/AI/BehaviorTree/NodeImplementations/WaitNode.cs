using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitNode : ActionNode
{
    public float WaitTime = 1;
    private float timeWaiting;

    public override void OnEntered()
    {
        timeWaiting = 0;
    }

    public override void OnExit()
    {
        
    }

    public override NodeStates OnUpdate()
    {
        timeWaiting += Time.deltaTime;

        if (timeWaiting >= WaitTime)
        {
            return NodeStates.Succeeded;
        }

        return NodeStates.Running;
    }
}
