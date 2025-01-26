using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKing : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    public int lives = 3;


    public void Touched()
    {
        if (lives > 0)
        {
            lives--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
