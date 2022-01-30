using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider1 : MonoBehaviour
{
    public int carHP = 12;

    public CarController Speed;
    public float accel = 1f;

   void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name != "Ground") //hits anything will slow car down.
        {
            carHP = carHP - 4;
            accel = 1f;
            Debug.Log(carHP);
        }

        if (collisionInfo.collider.tag == "Civilan")
        {
            //bad boy modifier
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (carHP < 1)
        {
            //game reset? - after implmenting checkpoint system
        }
    }
}
