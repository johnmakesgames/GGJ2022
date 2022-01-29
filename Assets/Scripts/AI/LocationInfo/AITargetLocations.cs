using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargetLocations
{
    private static List<Vector3> GetAllLocations(string tagToSearchFor)
    {
        var allLocations = GameObject.FindGameObjectsWithTag(tagToSearchFor);
        List<Vector3> destinations = new List<Vector3>();

        foreach (var obj in allLocations)
        {
            destinations.Add(obj.transform.position);
        }

        return destinations;
    }

    public static Vector3 GetRandomLocation(string tagToSearchFor)
    {
        var destinations = GetAllLocations(tagToSearchFor);
        return destinations[Random.Range(0, destinations.Count - 1)];
    }

    public static Vector3 GetClosestLocation(Vector3 currentLocation)
    {
        var destinations = GetAllLocations("AiDestination");
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
}
