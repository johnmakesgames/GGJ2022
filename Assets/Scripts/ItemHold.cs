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
                Vector3 newPos = mPlayer.transform.position + (mPlayer.transform.forward); // keep
                this.transform.position = new Vector3(newPos.x, mCurrentOffest.y, newPos.z);
                this.transform.rotation = mPlayer.transform.rotation ;

                if (Input.GetMouseButtonDown(0))
                {
                    UseItem();
                }

                if (Input.GetMouseButtonUp(0))
                {
                    EndUseItem();
                }
            }
            else
            {
                this.transform.position = mPlayer.transform.position + mCurrentOffest;

            }
        
            if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("item equipped");
                mEquipped = !mEquipped;

                if (mEquipped)
                {             
                    OnItemEquipped.Invoke();
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
        mHeld = !mHeld;
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
