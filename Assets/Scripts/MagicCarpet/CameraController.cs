using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCarpet
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Player player;

        private Vector3 _offset;
        
        void Start()
        {
            _offset = transform.position - player.transform.position;
        }
        
        void Update()
        {
            if (player != null)
            {
                transform.position = player.transform.position + _offset;
            }
        }
    }
}
