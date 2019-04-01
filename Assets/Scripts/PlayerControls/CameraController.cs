using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    Transform pivot;

    float lerpSpeed = 10f;
    float xRotateSpeed = 2.5f;
    float yRotateSpeed = 5f;

    float maxViewAngle = 65f;
    float minViewAngle = -65f;

    void Start()
    {
        pivot = gameObject.transform.GetChild(0);
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;
        offset = target.position - transform.position;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * yRotateSpeed;
        target.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * xRotateSpeed;
        pivot.Rotate(-vertical, 0, 0);

        if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(45f, 0f, 0f);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f - minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(315f, 0f, 0f);
        }

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion camRotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (camRotation * offset);

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
        }
        transform.LookAt(target);

        /*
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, target.position.x - offset.x, lerpSpeed * Time.deltaTime),
            Mathf.Lerp(transform.position.y, target.position.y - offset.y, lerpSpeed * Time.deltaTime),
            Mathf.Lerp(transform.position.z, target.position.z - offset.z, lerpSpeed * Time.deltaTime));

        // Quaternion.LookRotation(transform.forward, offset); turns camera upside down!!!
        Quaternion lookRotation = Quaternion.FromToRotation(transform.forward, offset);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, lerpSpeed * Time.deltaTime);
        */

    }
}
