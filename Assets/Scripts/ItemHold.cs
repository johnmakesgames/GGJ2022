using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemHold : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnUseItemEvent;

    public GameObject mPlayer;
    public Vector3 mOffest;

    bool mHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && mHeld)
        {
            mHeld = false;
        }

        if(mHeld)
        {
            this.transform.position = mPlayer.transform.position + mOffest;

            if(Input.GetMouseButtonDown(0))
            {
                UseItem();
            }
        }

    }
    public void OnDestroy()
    {
        OnUseItemEvent.RemoveAllListeners();
    }

    public void InteractWithItem() //pick up and drop
    {
        mHeld = !mHeld;
    }

    public void UseItem()
    {
        OnUseItemEvent.Invoke();
    }
}
