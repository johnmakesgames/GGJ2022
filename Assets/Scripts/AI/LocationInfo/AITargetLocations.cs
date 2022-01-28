using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargetLocations
{
    List<Vector3> destinations;

    AITargetLocations()
    {
        var allLocations = GameObject.FindGameObjectsWithTag("AiDestination");
        destinations = new List<Vector3>();

        foreach (var obj in allLocations)
        {
            destinations.Add(obj.transform.position);
        }
    }

    public Vector3 GetRandomLocation()
    {
        return destinations[Random.Range(0, destinations.Count - 1)];
    }

    public Vector3 GetClosestLocation(Vector3 currentLocation)
    {
        Vector3 closestDestination = destinations[0];
        float closestDistance = Vector3.Distance(currentLocation, destinations[0]);

        foreach (var dest in destinations)
        {
            float distance = Vector3.Distance(currentLocation, dest);
            if (distance < closestDistance)
            {
                closestDestination = dest;
                closestDistance = distance;
            }
        }

        return closestDestination;
    }

    static AITargetLocations instance = null;
    public static AITargetLocations Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new AITargetLocations();
            }

            return instance;
        }
    }
}
