using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAnimationManager : MonoBehaviour
{
    Animator animator;
    Vector3 lastFramePos = new Vector3(0, 0, 0);
    public bool isAgentMoving;
    public bool isAgentRunning;

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
        animator.SetBool("Moving", isAgentMoving);
        animator.SetBool("Running", isAgentRunning);
    }
}
