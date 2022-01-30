using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunFromPlayerNode : ActionNode
{
    Vector3 positionToGoTo = new Vector3(0, 0, 0);
    Vector3 positionLastFrame = new Vector3(0, 0, 0);
    float timeNotMoving = 0;
    public override void OnEntered()
    {
        positionToGoTo = new Vector3(0, 0, 0);
        positionLastFrame = new Vector3(0, 0, 0);
        timeNotMoving = 0;

        Vector3 vectorToPlayer = GameObject.FindGameObjectWithTag("Player").transform.position - parent.transform.position; 
        positionToGoTo = parent.transform.position + (vectorToPlayer.normalized * 50);
        NavMeshPath path = new NavMeshPath();
        parent.GetComponent<NavMeshAgent>().CalculatePath(positionToGoTo, path);
        parent.GetComponent<NavMeshAgent>().SetPath(path);
    }

    public override void OnExit()
    {
        
    }

    public override NodeStates OnUpdate()
    {
        if (positionLastFrame == this.parent.transform.position)
        {
            timeNotMoving += Time.deltaTime;
        }

        if (timeNotMoving >= 0.5f)
        {
            return NodeStates.Succeeded;
        }

        if (this.parent.transform.position.y < -4)
        {
            parent.GetComponent<NavMeshAgent>().speed = 10;
        }
        else
        {
            parent.GetComponent<NavMeshAgent>().speed = 5.0f;
        }

        positionLastFrame = this.parent.transform.position;

        float distance = Vector3.Distance(parent.transform.position, positionToGoTo);
        if (distance > 0.6f)
        {
            return NodeStates.Running;
        }
        else
        {
            return NodeStates.Succeeded;
        }
    }
}
