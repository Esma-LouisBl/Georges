using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocWave : MonoBehaviour
{
    [SerializeField]
    private GameObject _chocWave;
    private Transform _initialChocWave;
    private int j = 40;

    void Start()
    {
        _initialChocWave = gameObject.transform;
        StartCoroutine(ChockingWave());
    }
    private IEnumerator ChockingWave()
    {
        _chocWave.transform.localScale = _initialChocWave.localScale;
        while (j > 0)
        {
            _chocWave.transform.localScale += new Vector3(0.25f, 0, 0.25f);
            yield return new WaitForSeconds(0.05f);
            j -= 1;
        }
        Destroy(gameObject);
    }
}
