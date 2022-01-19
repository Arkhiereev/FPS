using UnityEngine;
using UnityEngine.EventSystems;

public class Shot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;
    [SerializeField] private float bulletSpeed;

    // void Update()
    public void OnPointerDown(PointerEventData eventData)
    // if (Input.touchCount > 0 && Input.GetTouch(0).tapCount == 2 && Input.GetTouch(0).phase == TouchPhase.Began)
    {
        GameObject bulletGO = Instantiate<GameObject>(bullet);
        bulletGO.transform.position = gun.transform.position;
        Rigidbody bulletRB = bulletGO.GetComponent<Rigidbody>();
        bulletRB.velocity = gun.transform.up * bulletSpeed;
    }

       // Ray ray = new Ray(transform.position, transform.forward);
       // Debug.DrawRay(transform.position, transform.up * 10, Color.red);
    
}
