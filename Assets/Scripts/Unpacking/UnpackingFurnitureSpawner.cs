using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnpackingFurnitureSpawner : MonoBehaviour
{
    public List<GameObject> FurnitureObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FurnitureObjects.Count == 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void Spawn()
    {
        if (FurnitureObjects.Count != 0)
        {
            int itemID = Random.Range(0, FurnitureObjects.Count);

            GameObject obj = Instantiate(FurnitureObjects[itemID], transform.parent);

            if (obj != null)
            {
                FurnitureObjects.RemoveAt(itemID);
            }
        }
    }
}
