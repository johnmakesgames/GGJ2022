using UnityEngine;
using UnityEngine.AI;

public class CarCollider1 : MonoBehaviour
{
    public int carHP = 12;
    public CarController Speed;
    public float accel = 1f;

    public GameObject humanplayer;

   void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name != "Ground") //hits anything will slow car down.
        {
            carHP = carHP - 4;
            accel = 1f;
            Debug.Log(carHP);
        }

        if (collisionInfo.collider.tag == "Pedestrian")
        {
            humanplayer.GetComponent<MoralityTracker>().badBoyPoints++;
            collisionInfo.gameObject.GetComponent<Animator>().SetBool("Alive", false);
            Destroy(collisionInfo.gameObject.GetComponent<NavMeshAgent>());
            Destroy(collisionInfo.gameObject.GetComponent<CapsuleCollider>());
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
