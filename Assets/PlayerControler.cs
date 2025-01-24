using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static float RestrictAngle(float angle, float angleMin, float angleMax) //definit l'angle maximum et l'angle minimum et s'assure qu'ils ne sont pas depasses
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

    [Header("References")]
    public Transform head; //tete du personnage, a attribuer a la cameraa

    void Start() //bloque le curseur
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        Cursor.visible = false;
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
