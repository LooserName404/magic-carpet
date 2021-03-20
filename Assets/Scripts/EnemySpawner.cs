using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int startZ = 20;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(enemy, new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), startZ), Quaternion.identity);
        }
    }
}
