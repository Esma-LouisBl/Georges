using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableEnemy4 : MonoBehaviour
{
    [SerializeField]
    private Enemy4 _enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            _enemy.Touched();

            Destroy(collision.gameObject);
        }
    }
}
