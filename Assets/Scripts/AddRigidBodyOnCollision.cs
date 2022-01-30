using UnityEngine;

public class AddRigidBodyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.AddComponent<Rigidbody>();
        Destroy(this);
    }
}