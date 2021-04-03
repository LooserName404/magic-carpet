using UnityEngine;
using Random = UnityEngine.Random;

namespace MagicCarpet
{
    public class TileSpawner : MonoBehaviour
    {
        private const int TILE_LENGTH = 8;

        private int _currentZ;

        [SerializeField] private Tile[] obstacleTiles;
        [SerializeField] private Tile[] safeTiles;

        private void Start()
        {
            _currentZ = -2;
            InstantiateTiles(30);
        }

        private void Update()
        {
            if (Player.Instance.transform.position.z * TILE_LENGTH - (_currentZ * TILE_LENGTH) > 15)
            {
                InstantiateTiles(30);
            }
        }

        private void InstantiateTiles(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Tile tile = _currentZ % 3 == 0
                    ? obstacleTiles[Random.Range(0, obstacleTiles.Length)]
                    : safeTiles[Random.Range(0, safeTiles.Length)];
                var spawned = Instantiate(tile, new Vector3(0, 0, _currentZ * TILE_LENGTH), Quaternion.identity);
                spawned.transform.parent = transform;
                _currentZ++;
            }
        }
    }
}