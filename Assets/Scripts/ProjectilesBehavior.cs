using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesBehavior : MonoBehaviour
{
    private float _speed = 5f;
    private float _timeTillEnd = 5;

    private void Start()
    {
        StartCoroutine(TimeToSlow());
    }
    void Update()
    {
        transform.position += ((-transform.right * Time.deltaTime * _speed) + new Vector3(0,Random.Range(-0.01f,0.01f), Random.Range(-0.01f, 0.01f)));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private IEnumerator TimeToSlow()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            _speed -= 0.25f;
            _timeTillEnd -= 1;
            if (_timeTillEnd < 0)
            {
                BubbleExplosion();
            }
        }
    }

    private void BubbleExplosion()
    {
        Destroy(gameObject);
    }
}