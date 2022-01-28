using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterNode : DecoratorNode
{
    public override void OnEntered()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public override NodeStates OnUpdate()
    {
        child.Update();

        return NodeStates.Running;
    }
}
