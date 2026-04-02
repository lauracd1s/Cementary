using UnityEngine;

public class TouchManager : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Detecta si tocaste un fantasma
                    if (hit.transform.CompareTag("Fantasma"))
                    {
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
    }
}