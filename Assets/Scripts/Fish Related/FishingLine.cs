using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    [SerializeField] private LineRenderer mFishLineRenderer;
    private Transform[] points;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       for(int i = 0; i <points.Length; i++)
       {
            mFishLineRenderer.SetPosition(i, points[i].position);
       }
    }

    public void SetUpLine(Transform[] points)
    {
        mFishLineRenderer.positionCount = points.Length;
        this.points = points;
    }
}
