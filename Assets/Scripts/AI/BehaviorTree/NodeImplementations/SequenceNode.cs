using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : CompositeNode
{
    int currentNodeIndex;

    public override void OnEntered()
    {
        currentNodeIndex = 0;
    }

    public override void OnExit()
    {
        
    }

    public override NodeStates OnUpdate()
    {
        var activeNode = children[currentNodeIndex];

        switch (activeNode.Update())
        {
            case NodeStates.Running:
                return NodeStates.Running;
            case NodeStates.Failed:
                return NodeStates.Running;
            case NodeStates.Succeeded:
                currentNodeIndex++;
                break;
        }

        return (currentNodeIndex == children.Count) ? NodeStates.Succeeded : NodeStates.Running;
    }
}
