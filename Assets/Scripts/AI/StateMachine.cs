using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    GameObject owner;

    IState ActiveState;
    List<IState> States = new List<IState>();

    [SerializeField]
    List<string> PotentialStates;

    // Start is called before the first frame update
    void Start()
    {
        owner = this.gameObject;

        foreach (var state in PotentialStates)
        {
            switch (state)
            {
                case "WalkToLocation":
                    States.Add(new WalkToLocation(owner));
                    break;
                case "DoNothing":
                    States.Add(new DoNothing());
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var potentialStates = new List<IState>();
        foreach (var state in States)
        {
            if (state.CanRunState())
            {
                potentialStates.Add(state);
            }
        }


    }
}
