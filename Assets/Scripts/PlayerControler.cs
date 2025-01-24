using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -100)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }


    public Transform head;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);
    }

    private void LateUpdate()
    {
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;
        e.x = RestrictAngle(e.x, -85f, 85f);
        head.eulerAngles = e;
    }
}
