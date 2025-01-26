using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour

{
    private int i = 6;
    public ChocWave WavePrefab;

    public Transform SpawnOffset;

    [SerializeField]
    private AudioSource _audioSource;

    void Start()
    {
        StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        while (i > 0)
        {
            yield return new WaitForSeconds(0.07f);
            transform.localPosition += new Vector3(0, 0.2f, 0);
            i -= 1;
        }
        i = 4;
        while (i > 0)
        {
            yield return new WaitForSeconds(0.15f);
            transform.localPosition += new Vector3(0, 0.2f, 0);
            i -= 1;
        }
        i = 4;
        StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        while (i > 0)
        {
            yield return new WaitForSeconds(0.15f);
            transform.localPosition += new Vector3(0, -0.2f, 0);
            i -= 1;
        }
        i = 6;
        while (i > 0)
        {
            yield return new WaitForSeconds(0.07f);
            transform.localPosition += new Vector3(0, -0.2f, 0);
            i -= 1;
        }
        i = 6;
        _audioSource.Play();
        StartCoroutine(Jump());
        Instantiate(WavePrefab, SpawnOffset.position, SpawnOffset.rotation);
    }
}
