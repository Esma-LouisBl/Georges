using UnityEngine;

public class DestroyableEnemyBridge : MonoBehaviour
{
    [SerializeField]
    private EnemyBridge _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            _enemy.Touched();

            Destroy(other.gameObject);
        }
    }
}
