using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCarpet
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Player player;

        private Vector3 _offset;
        // Start is called before the first frame update
        void Start()
        {
            _offset = transform.position - player.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (player != null)
            {
                transform.position = player.transform.position + _offset;
            }
        }
    }
}
