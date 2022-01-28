using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public GameObject mFishIndicator;
    public GameObject mPlayer;

    bool mCurrentlyHeld = true;
    bool mCanCastRod = true;
    bool mRodActive = false;
    bool mFishBitten = false;

    public float mReelInSpeed = 3f;
    public float mCastDistance = 1000f;
    public float mGrabDistance = 1f;
    public Vector3 mOffsetFromRod;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mCurrentlyHeld)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(!mRodActive && mCanCastRod)
                {
                    CastLine();
                }
                else if (mFishBitten)
                {
                    ReelInLine();
                }
                else if(mRodActive)
                {
                    ImmediateReelIn();
                }
            }
        }
    }

    bool CanCast()
    {
        return mCanCastRod;
    }

    void CastLine()
    {
        //Fire indicator to x distance in look direction
        Vector3 movement = new Vector3(mPlayer.transform.forward.x * mCastDistance, 0, mPlayer.transform.forward.z * mCastDistance);
        mFishIndicator.transform.position += new Vector3(mPlayer.transform.forward.x * mCastDistance, 0, mPlayer.transform.forward.z * mCastDistance);// mPlayer.transform.forward * mCastDistance;
        Debug.Log(movement);
        Debug.Log("Cast line");
        mRodActive = true;
        mCanCastRod = false;
        NotifyFishRodCast();
    }

    void ReelInLine()
    {
        mFishIndicator.transform.position -= mPlayer.transform.forward * mReelInSpeed * Time.deltaTime;
        Debug.Log("Reel In");

        float distance = Vector3.Distance(this.transform.position, mFishIndicator.transform.position);
        if(distance <= mGrabDistance)
        {
            SuccessfulCatch();
        }
    }

    void ImmediateReelIn()
    {
        Debug.Log("Reel In immediate");
        mFishIndicator.transform.position = this.transform.position + mOffsetFromRod;
        mCanCastRod = true;
        FailedCatch();
    }

    void RodPickedUp()
    {
        mCurrentlyHeld = true;
    }

    void RodPutDown()
    {
        mCurrentlyHeld = false;
    }

    void NotifyFishRodCast()
    {
        //Notify fish that bait is in the water
    }

    void NotifyFishBite()
    {
        //fire prompt to player UI
        mFishBitten = true;
    }

    void SuccessfulCatch()
    {
        //play animation and add to inventory
        mRodActive = false;
        mFishBitten = false;
    }

    void FailedCatch()
    {
        mRodActive = false;
        mFishBitten = false;
    }
}
