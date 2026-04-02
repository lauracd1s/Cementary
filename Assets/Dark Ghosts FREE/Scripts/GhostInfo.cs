using UnityEngine;
using UnityEngine.InputSystem;

public class GhostInfo : MonoBehaviour
{
    [Header("Información del fantasma")]
    public string nombreFantasma = "Fantasma Desconocido";
    [TextArea]
    public string descripcion = "Un espíritu que vaga por el cementerio...";
     [Header("Sonido")]
    public AudioClip sonidoFantasma;  // ← nuevo

    private AudioSource audioSource; 
     void Start()
    {
        audioSource = GetComponent<AudioSource>();  // ← nuevo
    }

    void Update()
    {
        var touchscreen = Touchscreen.current;
        if (touchscreen != null)
        {
            foreach (var touch in touchscreen.touches)
            {
                if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    DetectarToque(touch.position.ReadValue());
                }
            }
        }

        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            DetectarToque(Mouse.current.position.ReadValue());
        }
    }

    void DetectarToque(Vector2 posicion)
    {
        Ray ray = Camera.main.ScreenPointToRay(posicion);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == this.transform || hit.transform.IsChildOf(this.transform))
            {
                if (audioSource != null && sonidoFantasma != null)
                    audioSource.PlayOneShot(sonidoFantasma);
                GhostPanelManager.Instance.MostrarPanel(nombreFantasma, descripcion, this.transform);
            }
        }
    }
}