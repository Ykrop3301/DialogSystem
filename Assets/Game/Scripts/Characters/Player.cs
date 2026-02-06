using UnityEngine;

namespace Characters
{
	public class Player : MonoBehaviour
	{

        public float speed = 5f;
        public float RotationSpeed = 720f;

        void Update()
        {
            float moveVertical = Input.GetAxis("Vertical");

            Camera cam = Camera.main;
            Vector3 forward = cam.transform.TransformDirection(Vector3.forward);
            Vector3 right = cam.transform.TransformDirection(Vector3.right);

            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            Vector3 movement = forward * moveVertical * speed * Time.deltaTime;

            transform.Translate(movement, Space.World);

            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);
            }
        }
    }
}