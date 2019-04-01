using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public float speed;
    public Vector3 target = Vector3.zero;

    CharacterController cc;

    public bool atTarget = false;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        if (target != Vector3.zero)
        {
            Vector3 offset = target - transform.position;
            //Get the difference.
            if (offset.magnitude > .1f)
            {
                // If we're further away than .1 unit, move towards the target.
                // The minimum allowable tolerance varies with the speed of the object and the framerate. 
                // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
                offset = offset.normalized * speed;

                if(!cc.isGrounded)
                {
                    offset.y = offset.y + (Physics.gravity.y * Time.deltaTime);
                }
                //normalize it and account for movement speed.
                cc.Move(offset * Time.deltaTime);
                //actually move the character.
            }
        }
        else
        {
            atTarget = true;
        }
    }
}
