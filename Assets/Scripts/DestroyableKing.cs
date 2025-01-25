using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableKing : MonoBehaviour
{
    [SerializeField]
    private EnemyKing _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            _enemy.Touched();

            Destroy(other.gameObject);
        }
    }
}
