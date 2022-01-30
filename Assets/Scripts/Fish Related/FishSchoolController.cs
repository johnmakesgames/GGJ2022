using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSchoolController : MonoBehaviour
{
    private GameObject[] mFish;

    // Start is called before the first frame update
    void Start()
    {
        mFish = GameObject.FindGameObjectsWithTag("Fish");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NotifyRodCast(Transform rodTransform)
    {
        Debug.Log("School controller notify");

        for (int i = 0; i < mFish.Length; ++i)
        {
            mFish[i]?.GetComponent<FishController>()?.NotfiyRodCast(rodTransform);
        }
    }
}
