using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableEnemyBridge : MonoBehaviour
{
    [SerializeField]
    private EnemyBridge _enemy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            _enemy.Touched();

            Destroy(collision.gameObject);
        }
    }
}
