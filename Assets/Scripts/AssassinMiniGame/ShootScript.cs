using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShootScript : MonoBehaviour
{

    public float damage = 100f;

    public Camera playerCamera;

    public GameObject AssassinVictim;

    [SerializeField] private Image scopeOverlay;


    private void Start()
    {
        scopeOverlay.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ScopeIn();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            ScopeOut();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            if (AssassinVictim.CompareTag("AssassinVictim"))
            {
                Debug.Log(hit.transform.name);
            }
        }


    }

    void ScopeIn()
    {
        scopeOverlay.enabled = true;
        playerCamera.fieldOfView = 5;
    }

    void ScopeOut()
    {
        scopeOverlay.enabled = false;
        playerCamera.fieldOfView = 65;
    }

}
