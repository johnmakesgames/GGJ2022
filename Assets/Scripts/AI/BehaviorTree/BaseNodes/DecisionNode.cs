using System;

public class DecisionNode : INode
{
    public INode trueNode;
    public INode falseNode;
    private INode nodeToRun;

    public Func<bool> Comparator;

    public override void OnEntered()
    {
        nodeToRun = (Comparator()) ? trueNode : falseNode;

        nodeToRun.OnEntered();
    }

    public override void OnExit()
    {
        nodeToRun.OnExit();
    }

    public override NodeStates OnUpdate()
    {
        currentState = nodeToRun.OnUpdate();
        return currentState;
    }
}
