using UnityEngine;

public class PlayerMovemant : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Joystick_ joystick_;
    [SerializeField] private HeadRotation mainCamera;

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, mainCamera.transform.rotation.eulerAngles.y, 0);

        Vector3 direction = Vector3.forward * joystick_.input.y + Vector3.right * joystick_.input.x;
        GetComponent<Rigidbody>().velocity = transform.TransformDirection(direction * speed);
    }
}
