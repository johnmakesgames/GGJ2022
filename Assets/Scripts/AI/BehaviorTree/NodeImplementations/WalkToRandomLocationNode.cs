using UnityEngine;
using UnityEngine.AI;

public class WalkToRandomLocationNode : ActionNode
{
    float timeNotMoving = 0;
    Vector3 positionLastFrame = new Vector3(0, 0, 0);
    Vector3 positionToGoTo = new Vector3(0, 0, 0);
    public override void OnEntered()
    {
        positionToGoTo = AITargetLocations.GetRandomLocation("AiDestination");
        NavMeshPath path = new NavMeshPath();
        parent.GetComponent<NavMeshAgent>().CalculatePath(positionToGoTo, path);
        parent.GetComponent<NavMeshAgent>().SetPath(path);
        timeNotMoving = 0;
        positionLastFrame = new Vector3(0, 0, 0);
    }

    public override void OnExit()
    {
        positionToGoTo = new Vector3(0, 0, 0);
    }

    public override NodeStates OnUpdate()
    {
        if (positionLastFrame == this.parent.transform.position)
        {
            timeNotMoving += Time.deltaTime;
            if (parent.GetComponent<AIAnimationManager>())
            {
                parent.GetComponent<AIAnimationManager>().isAgentMoving = false;
                parent.GetComponent<AIAnimationManager>().isAgentRunning = false;
            }
        }
        else
        {
            if (parent.GetComponent<AIAnimationManager>())
            {
                parent.GetComponent<AIAnimationManager>().isAgentMoving = true;
                parent.GetComponent<AIAnimationManager>().isAgentRunning = false;
            }
        }

        var manager = MoralityManager.GetMoralityManager();
        if (manager.Karma < -5)
        {
            return NodeStates.Succeeded;
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
            parent.GetComponent<NavMeshAgent>().speed = 3.5f;
        }

        positionLastFrame = this.parent.transform.position;

        float distance = Vector3.Distance(parent.transform.position, positionToGoTo);
        if (distance > 0.6f)
        {
            return NodeStates.Running;
        }
        else
        {
            //parent.GetComponent<NavMeshAgent>().ResetPath();
            return NodeStates.Succeeded;
        }

    }
}
