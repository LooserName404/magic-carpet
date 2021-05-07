using System.Collections;
using UnityEngine;

namespace MagicCarpet
{
    public class Tile : MonoBehaviour
    {
        private void Update()
        {
            if (Player.Instance != null && transform.position.z + 4 < Player.Instance.transform.position.z)
            {
                StartCoroutine(Delete());
            }
        }

        private IEnumerator Delete()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }
    }
}