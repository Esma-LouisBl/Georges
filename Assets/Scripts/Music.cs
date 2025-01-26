using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioSource _source;
    void Start()
    {
        _source.Play();
    }
}
