using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnBiteRodEvent;

    [SerializeField]
    private float mSwimRadius = 10f;
    [SerializeField]
    private float mInterstRadius = 10f;
    [SerializeField]
    private float mBiteDistance = 5f;

    private Transform mTargetPosition;

    bool mRodCast = false;
    bool mCaught = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDestroy()
    {
        OnBiteRodEvent.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        //Behaviours

        //Swim Around
        if(!mCaught)
        {
            if(mRodCast)
            {
                float distance = Vector3.Distance(mTargetPosition.position, this.transform.position);
                if (distance <= mBiteDistance)
                {
                    Debug.Log("in bite range");
                    BiteRod();
                }
                else
                {
                    PassiveSwim();
                }
            }
            else
            {
                PassiveSwim();
            }
        }
    }

    void PassiveSwim()
    {
        //Swim around in mSwimRadius
    }

    public void NotfiyRodCast(Transform rodTrans)
    {
        Debug.Log("Fish notified");

        //Switch to interested in rod state
        float distance = Vector3.Distance(rodTrans.transform.position, this.transform.position);
        if(distance <= mInterstRadius)
        {
            Debug.Log("Fish in range");

            //state machine interest flag
            mTargetPosition = rodTrans.transform;
            mRodCast = true;
        }
    }

    public void BiteRod()
    {
        //Notfiy player/rod of the bite
        OnBiteRodEvent.Invoke();
    }

    public void OnCaught()
    {
        //Just remove from scene for now 
        //Destroy(this);
        Destroy(this.gameObject);
    }
}
