 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    [SerializeField]
    private FishSchoolController mFishController;
    [SerializeField]
    private float mRotateSpeed = 10;

    public GameObject mFishIndicator;
    public GameObject mPlayer;
    public Transform mTopOfRod;

    bool mRodActive = false;
    bool mFishBitten = false;
    bool mReelingIn = false;
    bool mEquipped = false;

    public float mReelInSpeed = 3f;
    public float mCastDistance = 1000f;
    public float mGrabDistance = 10f;
    public Vector3 mOffsetFromRod;

    FishController mBittenFish;

    float mLineTension = 0f;
    float mMaxLineTension = 10f;

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
        //Move rod left and right
        /*
        Vector3 move = transform.right * x + transform.forward * z;
        mPlayerController.Move(move * speed * Time.deltaTime);
        */
        if(mEquipped)
        {
            if (mRodActive)
            {
                float x = Input.GetAxis("Horizontal");
                Vector3 move = mPlayer.transform.right * x * Time.deltaTime;
                //Debug.Log(this.transform.eulerAngles);
                //Debug.Log(move);

                this.transform.RotateAround(this.transform.position, mPlayer.transform.forward, x * Time.deltaTime * mRotateSpeed);
                //Cap left right motion to stay on screen
                //do some fancy quaternion math to make rod rotation nice


                if (mReelingIn)
                {
                    Vector3 movementDir = mTopOfRod.position - mFishIndicator.transform.position;

                    movementDir.Normalize();
                    Vector3 movement = new Vector3(movementDir.x * mReelInSpeed, movementDir.y * mReelInSpeed, movementDir.z * mReelInSpeed);
                    //mFishIndicator.transform.position += movement;
                    // mBittenFish.GetComponentInParent<Transform>().position = mFishIndicator.transform.position;
                    if (mBittenFish.mCaught)
                    {
                        mBittenFish.AddPullForce(movement);
                    }
                    mFishIndicator.transform.position = mBittenFish.transform.position;

                    float distance = Vector3.Distance(mTopOfRod.position, mFishIndicator.transform.position);
                    if (distance <= mGrabDistance)
                    {
                        Debug.Log("Reel In finish");

                        SuccessfulCatch();
                    }

                    if (mLineTension >= mMaxLineTension)
                    {
                        LineBreak();
                    }
                }
                else
                {
                    if(mFishBitten)
                    {
                        mBittenFish.AddPullForce(Vector3.zero);
                        mFishIndicator.transform.position = mBittenFish.transform.position;
                    }            
                }
            }


        }   
    }
    public void CastLine()
    {
        if(!mRodActive)
        {
            mPlayer.GetComponent<Animator>().SetTrigger("BeginFish");
            mPlayer.GetComponent<Animator>().SetBool("Fishing", true);
            //Fire indicator to x distance in look direction
            Vector3 movement = new Vector3(mPlayer.transform.forward.x * mCastDistance, 0, mPlayer.transform.forward.z * mCastDistance);
            mFishIndicator.transform.position += new Vector3(mPlayer.transform.forward.x * mCastDistance, -2f, mPlayer.transform.forward.z * mCastDistance);// mPlayer.transform.forward * mCastDistance;
            mFishIndicator.transform.parent = null;
           // Debug.Log(movement);
           // Debug.Log("Cast line");
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


    void LineBreak()
    {
        FailedCatch();
        ImmediateReelIn();
    }

    void IncreaseLineTension(float val)
    {
        mLineTension += val;
    }

    void ReduceLineTension(float val)
    {
        mLineTension -= val;
    }

    public void EndUseRod()
    {
        ReelInLine();
    }

    public void ReelInLine()
    {
        if(mReelingIn)
        {
            mReelingIn = false;
        }
    }

    public void OnEquipped()
    {
        Debug.Log("rod equipped");

        mEquipped = !mEquipped;

        this.transform.eulerAngles += new Vector3(50, 0, 0);

        //place in front of player
    }

    void ImmediateReelIn()
    {
        Debug.Log("Reel In immediate");
        mFishIndicator.transform.position = mTopOfRod.position;
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
        mBittenFish.SetPlayerRight(mPlayer.transform.right);
    }

    void SuccessfulCatch()
    {
        mFishIndicator.transform.SetParent(this.transform);
        Debug.Log("Succesful catch");

        //play animation and add to inventory
        mReelingIn = false;
        mRodActive = false;
        mFishBitten = false;

        mBittenFish.OnCaught();
        mBittenFish = null;
        ImmediateReelIn();
        mLineTension = 0;

        mPlayer.GetComponent<MoralityTracker>().SignalActivityCompleted();
    }


    void FailedCatch()
    {
        Debug.Log("failed catch");

        mFishIndicator.transform.SetParent(this.transform);
        mRodActive = false;
        mFishBitten = false;
        mReelingIn = false;
        mFishBitten = false;
        mLineTension = 0;
    }
}
