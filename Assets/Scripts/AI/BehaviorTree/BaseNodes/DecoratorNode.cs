using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecoratorNode : INode
{
    public INode child;
}