using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jump = 10f;
    private float gravity = 16f;
    Vector3 direction;

    CharacterController controller;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(controller.isGrounded)
        {
            float yStore = direction.y;
            direction = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            direction = direction.normalized * speed;
            direction.y = yStore;
            if(Input.GetButtonDown("Jump"))
            {
                direction.y = jump;
            }
        }
        else
        {
            direction.y = direction.y + (Physics.gravity.y * gravity * Time.deltaTime);
        }
        controller.Move(direction * Time.deltaTime);
    }
}
