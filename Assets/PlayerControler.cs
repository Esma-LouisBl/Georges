using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
<<<<<<< HEAD
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
=======
    public Transform head;
    // Start is called before the first frame update
    void Start()
>>>>>>> parent of 8bf833b (Merge branch 'main' of https://github.com/Esma-LouisBl/Georges)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);
    }

    private void LateUpdate()
    {
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;
        //e.x = RestrictAngle(e.x, -85f, 85f);
        head.eulerAngles = e;
    }
}
