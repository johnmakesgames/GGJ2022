using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompositeNode : INode
{
    public List<INode> children = new List<INode>();
}