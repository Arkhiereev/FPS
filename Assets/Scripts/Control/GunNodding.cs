using UnityEngine;

public class GunNodding : MonoBehaviour
{
    [SerializeField] private HeadRotation mainCamera;

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(mainCamera.transform.rotation.eulerAngles.x + 90, mainCamera.transform.rotation.eulerAngles.y, 0);
    }
}
