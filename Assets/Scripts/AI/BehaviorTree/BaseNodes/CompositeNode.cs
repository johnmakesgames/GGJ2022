using System.Collections.Generic;

public abstract class CompositeNode : INode
{
    public List<INode> children = new List<INode>();
}