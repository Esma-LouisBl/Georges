using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKing : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    public int lives = 100;


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
