using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
