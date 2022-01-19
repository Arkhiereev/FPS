using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private PlayerMovemant player;

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
