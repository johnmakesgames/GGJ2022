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
    }

    public override void OnExit()
    {
        
    }

    public override NodeStates OnUpdate()
    {
        Vector3 vectorToPlayer = parent.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;
        positionToGoTo = parent.transform.position + (vectorToPlayer.normalized);
        NavMeshPath path = new NavMeshPath();
        parent.GetComponent<NavMeshAgent>().CalculatePath(positionToGoTo, path);
        parent.GetComponent<NavMeshAgent>().SetPath(path);


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
            parent.GetComponent<NavMeshAgent>().speed = 10.0f;
        }

        if (parent.GetComponent<AIAnimationManager>())
        {
            parent.GetComponent<AIAnimationManager>().isAgentMoving = true;
            parent.GetComponent<AIAnimationManager>().isAgentRunning = true;
        }

        positionLastFrame = this.parent.transform.position;

        float distance = Vector3.Distance(parent.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (distance < 10.0f)
        {
            return NodeStates.Running;
        }
        else
        {
            return NodeStates.Succeeded;
        }
    }
}
