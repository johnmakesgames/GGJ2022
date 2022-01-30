using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    [SerializeField]
    private FishSchoolController mFishController;

    public GameObject mFishIndicator;
    public GameObject mPlayer;
    public Transform mTopOfRod;

    bool mRodActive = false;
    bool mFishBitten = false;
    bool mReelingIn = false;

    public float mReelInSpeed = 3f;
    public float mCastDistance = 1000f;
    public float mGrabDistance = 10f;
    public Vector3 mOffsetFromRod;

    FishController mBittenFish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(mReelingIn)
        {
            Vector3 movementDir = mTopOfRod.position - mFishIndicator.transform.position;

            movementDir.Normalize();
            Vector3 movement = new Vector3(movementDir.x * mReelInSpeed, movementDir.y * mReelInSpeed, movementDir.z * mReelInSpeed);
            mFishIndicator.transform.position += movement;
            mBittenFish.GetComponentInParent<Transform>().position = mFishIndicator.transform.position;

            float distance = Vector3.Distance(mTopOfRod.position, mFishIndicator.transform.position);
            if (distance <= mGrabDistance)
            {
                Debug.Log("Reel In finish");

                SuccessfulCatch();
            }
        }
    }
    public void CastLine()
    {
        if(!mRodActive)
        {
            //Fire indicator to x distance in look direction
            Vector3 movement = new Vector3(mPlayer.transform.forward.x * mCastDistance, 0, mPlayer.transform.forward.z * mCastDistance);
            mFishIndicator.transform.position += new Vector3(mPlayer.transform.forward.x * mCastDistance, -20f, mPlayer.transform.forward.z * mCastDistance);// mPlayer.transform.forward * mCastDistance;
           
            Debug.Log(movement);
            Debug.Log("Cast line");
            mRodActive = true;
            NotifyFishRodCast();
        }
        else
        {
            if (mFishBitten)
            {
                mReelingIn = true;
            }
            else
            {
                FailedCatch();
                ImmediateReelIn();
            }
        }
    }

    public void ReelInLine()
    {
        if(mReelingIn)
        {
            mReelingIn = false;
        }
    }

    void ImmediateReelIn()
    {
        Debug.Log("Reel In immediate");
        mFishIndicator.transform.position = this.transform.position + mOffsetFromRod;
    }

    void NotifyFishRodCast()
    {
        //Notify fish that bait is in the water
        mFishController.NotifyRodCast(mFishIndicator.transform);
    }

    public void NotifyFishBite(FishController fish)
    {
        //fire prompt to player UI
        mBittenFish = fish;
        mFishBitten = true;
        Debug.Log("rod transform fish");
        mBittenFish.GetComponentInParent<Transform>().position = mFishIndicator.transform.position;
    }

    void SuccessfulCatch()
    {
        //play animation and add to inventory
        mReelingIn = false;
        mRodActive = false;
        mFishBitten = false;

        mBittenFish.OnCaught();
        mBittenFish = null;
        ImmediateReelIn();
    }

    void FailedCatch()
    {
        mRodActive = false;
        mFishBitten = false;
    }
}