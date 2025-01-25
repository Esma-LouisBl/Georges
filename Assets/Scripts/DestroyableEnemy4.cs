using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableEnemy4 : MonoBehaviour
{
    [SerializeField]
    private Enemy4 _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            _enemy.Touched();

            Destroy(other.gameObject);
        }
    }
}
