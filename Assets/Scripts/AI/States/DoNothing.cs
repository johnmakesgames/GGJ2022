using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNothing : IState
{
    float m_TimeToDoNothingFor = 5;
    float m_TimeDoingNothing = 0;

    private int m_statePriority = int.MinValue;
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

    public void Act()
    {
        m_TimeDoingNothing += Time.deltaTime;
    }

    public bool CanRunState()
    {
        if (m_TimeDoingNothing < m_TimeToDoNothingFor)
        {
            return true;
        }

        return false;
    }

    public void EnterState()
    {
        m_TimeDoingNothing = 0;
    }

    public void ExitState()
    {

    }
}
