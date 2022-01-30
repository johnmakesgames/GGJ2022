using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    List<GameObject> playableObjects = new List<GameObject>();
    GameObject activePlayer;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SetAsActivePlayer("FirstPersonPlayer");
        }
        else if (Input.GetKeyDown("c"))
        {
            SetAsActivePlayer("Car mkV");
        }
    }

    public void RegisterAsPlayer(GameObject obj)
    {
        playableObjects.Add(obj);
    }

    public void SetAsActivePlayer(string name)
    {
        var obj = playableObjects.Where(x => x.name == name).First();
        activePlayer?.SetActive(false);
        activePlayer = obj;
        activePlayer?.SetActive(true);
    }

    public void SetAsActivePlayer(GameObject obj)
    {
        if (playableObjects.Contains(obj))
        {
            activePlayer?.SetActive(false);
            activePlayer = obj;
            activePlayer?.SetActive(true);
        }
    }
}
