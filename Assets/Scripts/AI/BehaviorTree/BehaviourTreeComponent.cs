using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTreeComponent : MonoBehaviour
{
    [SerializeField]
    BehaviourTree behaviourTree;

    [SerializeField]
    string treeToRun;

    // Start is called before the first frame update
    void Start()
    {
        behaviourTree = InstantiatedTree.GetTree(treeToRun);
        behaviourTree.Parent = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        behaviourTree.Update();
    }
}
