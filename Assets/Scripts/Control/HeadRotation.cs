using UnityEngine;

public class HeadRotation: MonoBehaviour
{
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private float nodOscillation = 45;

    private float _rotX;
    private float _rotY;

    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).position.x > Screen.width / 4)
        {
            _rotX -= Input.GetTouch(0).deltaPosition.y * sensitivity;
            _rotX = Mathf.Clamp(_rotX, -nodOscillation, nodOscillation);
            _rotY += Input.GetTouch(0).deltaPosition.x * sensitivity;

            transform.eulerAngles = new Vector3(_rotX, _rotY, 0);
        }                    
    }
}