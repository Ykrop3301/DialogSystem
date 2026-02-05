using UnityEngine;

namespace Characters
{
	public class Player : MonoBehaviour
	{

        public float speed = 5f;
        public float RotationSpeed = 720f;

        void Update()
        {
            // Получаем ввод от игрока
            float moveVertical = Input.GetAxis("Vertical");

            // Получаем позицию камеры
            Camera cam = Camera.main;
            // Вычисляем направление вперед и вбок относительно камеры
            Vector3 forward = cam.transform.TransformDirection(Vector3.forward);
            Vector3 right = cam.transform.TransformDirection(Vector3.right);

            // Нормализуем направление
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            // Рассчитываем движение
            Vector3 movement = forward * moveVertical * speed * Time.deltaTime;

            // Передвижение персонажа
            transform.Translate(movement, Space.World);

            // Вращение игрока в направлении движения
            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed * Time.deltaTime);
            }
        }
    }
}