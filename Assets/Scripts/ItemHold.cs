using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemHold : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnUseItemEvent;
    [SerializeField]
    private UnityEvent OnItemUseRelease;
    [SerializeField]
    private UnityEvent OnItemEquipped;
    [SerializeField]
    private bool mFreezePlayerMovementWhenUsingItem = false;
    [SerializeField]
    private bool mFreezePlayerRotationWhenUsingItem = false;

    public GameObject mPlayer;
    public Vector3 mCurrentOffest;
    public Vector3 mEquippedRotation;
    private Quaternion mInitialRotation;

    
    bool mEquipped = false;
    bool mHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        mInitialRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(mHeld)
        {
            if (mEquipped)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    UseItem();
                }

                if (Input.GetMouseButtonUp(0))
                {
                    EndUseItem();
                }

                if (Input.GetButtonDown("Interact")) //drop item
                {
                    mHeld = false;
                    mEquipped = false;
                    EndUseItem();
                    this.transform.parent = null;
                    mPlayer.GetComponent<PlayerMovement>().mPlayerFixedLocation = false;
                    mPlayer.GetComponentInChildren<MouseLook>().mClampMouseLook = false;
                }
            }


            if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("item equipped");
                mEquipped = !mEquipped;

                if (mEquipped)
                {             
                    OnItemEquipped.Invoke();

                    Vector3 newPos = mPlayer.transform.position + (mPlayer.transform.forward);
                    this.transform.position = new Vector3(newPos.x, mCurrentOffest.y, newPos.z);
                    this.transform.rotation = mPlayer.transform.rotation;

                    if (mFreezePlayerMovementWhenUsingItem)
                    {
                        mPlayer.GetComponent<PlayerMovement>().mPlayerFixedLocation = true;
                    }

                    if(mFreezePlayerRotationWhenUsingItem)
                    {
                        mPlayer.GetComponentInChildren<MouseLook>().mClampMouseLook = true;
                    }
                }
                else
                { 
                    mPlayer.GetComponent<PlayerMovement>().mPlayerFixedLocation = false;
                    mPlayer.GetComponentInChildren<MouseLook>().mClampMouseLook = false;

                    Vector3 newPos = mPlayer.transform.position + (mPlayer.transform.forward * -1);
                    this.transform.position = new Vector3(newPos.x, mCurrentOffest.y, newPos.z);
                    this.transform.rotation = mPlayer.transform.rotation;
                }
            }
            
        }
    }

    public void OnDestroy()
    {
        OnUseItemEvent.RemoveAllListeners();
        OnItemUseRelease.RemoveAllListeners();
        OnItemEquipped.RemoveAllListeners();
    }

    public void InteractWithItem() //pick up and drop
    {
        Debug.Log("Interact with item");

        if(!mHeld)
        {
            mHeld = true;
            Vector3 newPos = mPlayer.transform.position + (mPlayer.transform.forward * -1);
            this.transform.position = new Vector3(newPos.x, mCurrentOffest.y, newPos.z);
            this.transform.rotation = mPlayer.transform.rotation;
            this.transform.parent = mPlayer.transform;
        }
    }

    public void UseItem()
    {
        OnUseItemEvent.Invoke();
    }

    public void EndUseItem()
    {
        OnItemUseRelease.Invoke();
    }
}
