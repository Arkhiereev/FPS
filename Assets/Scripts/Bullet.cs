using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Layers.Wall || collision.gameObject.layer == Layers.Enemy)
            Destroy(this.gameObject);
    }
}
