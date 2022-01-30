using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FishController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnBiteRodEvent;

 
    [SerializeField]
    private float mInterstRadius = 10f;
    [SerializeField]
    private float mBiteDistance = 5f;
    [SerializeField]
    private float mSwimSpeed = 2f;
    [SerializeField]
    float mMaxDistanceBeforeSwitch = 3f;


    private Transform mTargetPosition;

    private Vector3 mSwimCircleCentre;

    Vector3 mPreviousPos;

    bool mRodCast = false;
    public bool mCaught = false;
    bool mStruggling = false;
    bool mSwimRight = true;

    float mCurrentActivityTime = 0f;
    float mStruggleTime = 10f;
    float mRecargeTime = 5f;
    Vector3 mStartingPos;
    Vector3 mPullForce = Vector3.zero;
    Vector3 mPlayerRight = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        mSwimCircleCentre = this.transform.position + new Vector3(2, 0, 2);
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
                else if(distance <= mInterstRadius)
                {
                    SwimToBait();
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
        else
        {
            if(mStruggling)
            {
                //swim left and right
                mCurrentActivityTime += Time.deltaTime;

                if(mMaxDistanceBeforeSwitch <= Vector3.Distance(mStartingPos, this.transform.position))
                {
                    mSwimRight = !mSwimRight;
                }

                //Vector3 right = this.GetComponent<FishingRod>().mPlayer.transform.right;
                Vector3 right = mPlayerRight; //TEMP get player right vector
                if(mSwimRight)
                {
                    this.transform.forward = right;

                }
                else
                {
                    this.transform.forward = -right;

                }
                Debug.Log("struggling");

                this.transform.position += this.transform.forward * mSwimSpeed * Time.deltaTime;
                this.transform.position += mPullForce * Time.deltaTime * 10;

                if (mCurrentActivityTime >= mStruggleTime)
                {
                    mCurrentActivityTime = 0;
                    mStruggling = false;
                }
            }
            else
            {
                mCurrentActivityTime += Time.deltaTime;

                if(mCurrentActivityTime >= mRecargeTime)
                {
                    mCurrentActivityTime = 0;
                    mStruggling = true;
                    mSwimRight = !mSwimRight;
                }

                this.transform.position += mPullForce * Time.deltaTime * 20;

            }

        }
    }

    public void AddPullForce(Vector3 force)
    {
        mPullForce = force;

        if(force != Vector3.zero)
            mStartingPos = this.transform.position;
    }

    public void SetPlayerRight(Vector3 right)
    {
        mPlayerRight = right;
    }

    void PassiveSwim()
    {
        //Swim around in mSwimRadius
        mPreviousPos = this.transform.position;
        this.transform.RotateAround(mSwimCircleCentre, Vector3.up, mSwimSpeed * 10 * Time.deltaTime);
        Vector3 dir = this.transform.position - mPreviousPos;
        this.transform.forward = dir.normalized;
        //Vector3 radius = this.transform.position - mSwimCircleCentre;

    }
    
    void SwimToBait()
    {
        Vector3 dir = mTargetPosition.position - this.transform.position;
        this.transform.position += new Vector3(dir.x * mSwimSpeed * Time.deltaTime, dir.y * mSwimSpeed * Time.deltaTime, dir.z * mSwimSpeed * Time.deltaTime);
        this.transform.forward = dir.normalized;
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
        mCaught = true;
        mStruggling = true;
        mStartingPos = transform.position;
    }

    public void OnCaught()
    {
        //Just remove from scene for now 
        //Destroy(this);
        Destroy(this.gameObject);
    }
}
