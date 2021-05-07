using UnityEngine;

namespace MagicCarpet
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 1.0f;
        
        private float speed = 10.0f;

        public static Player Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Update()
        {
            Vector3 dir = Vector3.zero;

            dir.x = Input.acceleration.x;
            dir.y = Input.acceleration.y + 0.5f;

            if (dir.sqrMagnitude > 1)
            {
                dir.Normalize();
            }

            dir.z = forwardSpeed;
            dir *= Time.deltaTime;

            transform.Translate(dir * speed);
            transform.position = GetClampedPosition();

            speed += 0.0005f;
        }

        private Vector3 GetClampedPosition()
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.Clamp(pos.x, -4.75f, 4.75f);
            pos.y = Mathf.Clamp(pos.y, 0.75f, 6.75f);
            return pos;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
                GameController.GameOver();
            }
        }
    }
}
