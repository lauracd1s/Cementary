using UnityEngine;
using TMPro;

public class GhostPanelManager : MonoBehaviour
{
    public static GhostPanelManager Instance;

    public GameObject panelInfo;
    public TextMeshProUGUI textoNombre;
    public TextMeshProUGUI textoDescripcion;

    void Awake()
    {
        Instance = this;
        panelInfo.SetActive(false);
    }

    public void MostrarPanel(string nombre, string descripcion, Transform fantasma)
    {
        textoNombre.text = nombre;
        textoDescripcion.text = descripcion;
        panelInfo.SetActive(true);

        // El panel aparece encima del fantasma tocado
        panelInfo.transform.position = fantasma.position + Vector3.up * 1.5f;
        panelInfo.transform.LookAt(Camera.main.transform);
        panelInfo.transform.Rotate(0, 180, 0);
    }

    public void CerrarPanel()
    {
        panelInfo.SetActive(false);
    }
}