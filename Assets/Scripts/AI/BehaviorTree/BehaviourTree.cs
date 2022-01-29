using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BehaviourTree : ScriptableObject
{
    public INode rootNode;
    public INode.NodeStates treeState = INode.NodeStates.Running;
    public List<INode> allTreeNodes = new List<INode>();

    private GameObject m_Parent;
    public GameObject Parent
    {
        get
        {
            return m_Parent;
        }
        set
        {
            m_Parent = value;
            foreach (var node in allTreeNodes)
            {
                node.parent = m_Parent;
            }
        }
    }


    public INode.NodeStates Update()
    {
        if (treeState == INode.NodeStates.Running)
        {
            treeState = rootNode.Update();
        }

        return treeState;
    }

    public INode CreateNode(System.Type type)
    {
        INode node = ScriptableObject.CreateInstance(type) as INode;
        node.name = type.Name;
        node.Guid = Guid.NewGuid().ToString();
        node.parent = Parent;
        allTreeNodes.Add(node);

        return node;
    }

    public void DeleteNode(INode node)
    {
        allTreeNodes.Remove(node);
    }
}
