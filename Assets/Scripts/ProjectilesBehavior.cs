using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesBehavior : MonoBehaviour
{
    private float _speed = 5f; //vitesse de base
    private float _timeTillEnd = 5; //regle la portee/distance avant explosion de la bulle

    [SerializeField]
    private AudioSource _source;

    private void Start()
    {
        StartCoroutine(TimeToSlow());
    }
    void Update()
    {
        transform.position += ((-transform.right * Time.deltaTime * _speed) + new Vector3(Random.Range(-0.02f, 0.02f), Random.Range(-0.01f,0.01f), 0));
    }

    private void OnCollisionEnter2D(Collision2D collision) // ?marche pas T-T
    {
        Destroy(gameObject);
    }

    private IEnumerator TimeToSlow()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f); //temps attendu avant la decrementation de la vitesse
            _speed -= 0.25f; //diminution de la vitesse
            _timeTillEnd -= 1;
            if (_timeTillEnd < 0)
            {
                BubbleExplosion();
            }
        }
    }

    private void BubbleExplosion()
    {
        _source.Play();
        Destroy(gameObject);
    }
}