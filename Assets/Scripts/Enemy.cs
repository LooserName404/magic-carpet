using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.back * (5 * Time.deltaTime);
        if (transform.position.z < -5)
        {
            Destroy(gameObject);
        }
    }
}
