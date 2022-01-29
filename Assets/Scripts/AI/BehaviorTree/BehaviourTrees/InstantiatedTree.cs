/// <summary>
/// Class for Instantiating Behaviour Trees
/// </summary>
public class InstantiatedTree
{
    /// <summary>
    /// Creates a behaviour tree of a given name and returns it
    /// </summary>
    /// <param name="treeName">The name of the tree that will be instantiated</param>
    /// <returns></returns>
    public static BehaviourTree GetTree(string treeName)
    {
        BehaviourTree tree = null;

        switch (treeName)
        {
            case "TestAgentTree":
                tree = GetTestAgentTree();
                break;
            case "TestCarTree":
                tree = GetTestCarAgentTree();
                break;
            default:
                break;
        }

        return tree;
    }

    /// <summary>
    /// Creates a test tree for node testing.
    /// </summary>
    private static BehaviourTree GetTestAgentTree()
    {
        var tree = new BehaviourTree();
            var repeater = (RepeaterNode)tree.CreateNode(typeof(RepeaterNode));
                var decision = (DecisionNode)tree.CreateNode(typeof(DecisionNode));
                decision.Comparator = () => { return true; };
                    var sequence = (SequenceNode)tree.CreateNode(typeof(SequenceNode));
                        sequence.children.Add(tree.CreateNode(typeof(WalkToRandomLocationNode)));
                        sequence.children.Add(tree.CreateNode(typeof(WaitNode)));
                decision.trueNode = sequence;
                decision.falseNode = tree.CreateNode(typeof(DebugLogNode));
            repeater.child = decision;
        tree.rootNode = repeater;

        return tree;
    }

    private static BehaviourTree GetTestCarAgentTree()
    {
        var tree = new BehaviourTree();
        var repeater = (RepeaterNode)tree.CreateNode(typeof(RepeaterNode));
        var decision = (DecisionNode)tree.CreateNode(typeof(DecisionNode));
        decision.Comparator = () => { return true; };
        var sequence = (SequenceNode)tree.CreateNode(typeof(SequenceNode));
        sequence.children.Add(tree.CreateNode(typeof(DriveToRandomParkingSpaceNode)));
        sequence.children.Add(tree.CreateNode(typeof(WaitNode)));
        decision.trueNode = sequence;
        decision.falseNode = tree.CreateNode(typeof(DebugLogNode));
        repeater.child = decision;
        tree.rootNode = repeater;

        return tree;
    }
}