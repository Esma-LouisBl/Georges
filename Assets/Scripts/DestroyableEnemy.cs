using UnityEngine;

public class DestroyableEnemy : MonoBehaviour
{
    [SerializeField]
    private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bubble"))
        {
            _enemy.Touched();

            Destroy(other.gameObject);
        }
    }
}
