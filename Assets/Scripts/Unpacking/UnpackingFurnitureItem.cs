using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackingFurnitureItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshCollider[] colliders = GetComponentsInChildren<MeshCollider>();

        foreach(MeshCollider collider in colliders)
        {
            collider.convex = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + ": COLLISION");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(name + ": COLLISION EXIT");
    }
}
