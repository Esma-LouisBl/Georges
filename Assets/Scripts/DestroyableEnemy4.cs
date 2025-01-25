using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableEnemy4 : MonoBehaviour
{
    [SerializeField]
    private Enemy4 _enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            _enemy.Touched();
        }
    }
}
