public class RepeaterNode : DecoratorNode
{
    public override void OnEntered()
    {
        child.OnEntered();
    }

    public override void OnExit()
    {
        child.OnExit();
    }

    public override NodeStates OnUpdate()
    {
        child.Update();

        return NodeStates.Running;
    }
}