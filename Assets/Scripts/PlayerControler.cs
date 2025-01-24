using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static float RestrictAngle(float angle, float angleMin, float angleMax) //parametre la verification et la remise a niveau des maximums et minimums de l'angle de camera
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

    public Transform head; //gameobject representant la tete du joueur

    void Start()
    {
        Cursor.visible = false; //cache le curseur
        Cursor.lockState = CursorLockMode.Locked; //bloque le curseur au centre de l'ecran
    }


    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f); //tourne la camera sur l'axe horizontal
    }

    private void LateUpdate()
    {
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f; //2f : represente la vitesse a laquelle la camera monte
        e.x = RestrictAngle(e.x, -85f, 85f); //bloque la rotation de la camera
        head.eulerAngles = e; //tourne la camera sur l'axe vertical
    }
}