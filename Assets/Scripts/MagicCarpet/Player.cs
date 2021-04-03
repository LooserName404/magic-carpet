using UnityEngine;

namespace MagicCarpet
{
    public class Player : MonoBehaviour
    {
        // Move object using accelerometer
        float speed = 10.0f;

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

            // we assume that device is held parallel to the ground
            // and Home button is in the right hand

            // remap device acceleration axis to game coordinates:
            //  1) XY plane of the device is mapped onto XZ plane
            //  2) rotated 90 degrees around Y axis
            dir.x = Input.acceleration.x;
            dir.y = Input.acceleration.y + 0.5f;

            // clamp acceleration vector to unit sphere
            if (dir.sqrMagnitude > 1)
                dir.Normalize();

            dir.z = 1;

            // Make it move 10 meters per second instead of 10 meters per frame...
            dir *= Time.deltaTime;

            // Move object
            transform.Translate(dir * speed);
            transform.position = GetClampedPosition(); 
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
