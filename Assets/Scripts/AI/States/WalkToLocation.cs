using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToLocation : IState
{
    Vector3 destination = new Vector3(0, 0, 0);

    private int m_statePriority = 10;
    public int StatePriority
    {
        get
        {
            return m_statePriority;
        }
        set
        {
            m_statePriority = value;
        }
    }

    GameObject m_Owner;
    public WalkToLocation(GameObject owner)
    {
        m_Owner = owner;
        destination = AITargetLocations.Instance.GetRandomLocation();
    }

    public void Act()
    {
        Vector3 directionToMove = destination - m_Owner.GetComponent<Transform>().position;

        m_Owner.GetComponent<Transform>().position += directionToMove.normalized * 0.1f;
    }

    public bool CanRunState()
    {
        if ((m_Owner.GetComponent<Transform>().position - destination).magnitude > 0.5f)
        {
            return true;
        }

        return false;
    }

    public void EnterState()
    {
        destination = AITargetLocations.Instance.GetRandomLocation();
    }

    public void ExitState()
    {

    }
}
