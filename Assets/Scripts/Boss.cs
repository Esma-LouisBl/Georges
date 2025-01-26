using UnityEngine;

public class Boss : MonoBehaviour
{

    public int lives = 10;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("skibidi zob");
        if (other.gameObject.CompareTag("Bubble"))
        {
            Touched();

            Destroy(other.gameObject);
        }
    }

    public void Touched()
    {
        if (lives > 1)
        {
            lives--;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
