using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public Material toSwap;

    void Start()
    {
        
    }


    public void SwapMaterial()
    {
        GetComponent<Renderer>().sharedMaterial = toSwap;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
