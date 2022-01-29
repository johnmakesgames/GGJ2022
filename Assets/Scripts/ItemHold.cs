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
        if(mHeld)
        {
            this.transform.position = mPlayer.transform.position + mOffest;

            if(Input.GetMouseButtonDown(0))
            {
                UseItem();
            }

            if(Input.GetMouseButtonUp(0))
            {
                EndUseItem();
            }
        }

    }
    public void OnDestroy()
    {
        OnUseItemEvent.RemoveAllListeners();
        OnItemUseRelease.RemoveAllListeners();
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
