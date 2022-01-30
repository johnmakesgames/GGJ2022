using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRegisterer : MonoBehaviour
{
    public GameObject playerManager;

    // Start is called before the first frame update
    void Start()
    {
        playerManager.GetComponent<PlayerManager>().RegisterAsPlayer(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
