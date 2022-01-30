using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimationManager : MonoBehaviour
{
    Animator animator;
    Vector3 lastFramePos = new Vector3(0, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        lastFramePos = new Vector3(0, 0, 0);
    }

    public float movingSpeed;
    public float overrideSpeed = -1;
    // Update is called once per frame
    void Update()
    {
        bool isAgentMoving = false;

        movingSpeed = Vector3.Distance(lastFramePos, this.transform.position) * Time.deltaTime;

        if (overrideSpeed != -1)
        {
            movingSpeed = overrideSpeed;
        }

        if (movingSpeed >= 0.4f)
        {
            isAgentMoving = true;
        }

        animator.SetBool("Moving", isAgentMoving);
    }
}
