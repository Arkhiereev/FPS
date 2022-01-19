using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IPointerDownHandler
{
    private Color _color;
    private float _colorR = 1;

    void Update()
    {
        //if (Input.touchCount > 0) transform.localScale *= 1.01f;
        if (_colorR < .05f)
            Destroy(this.gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == Layers.Bullet)
        {
            _colorR -= .3f;
            _color = new Vector4(_colorR, 0, .5f, 1);      
            GetComponent<Renderer>().material.color = _color;

            Debug.Log(_color);
        }
    }
}
