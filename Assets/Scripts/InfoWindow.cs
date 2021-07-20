using UnityEngine;
using TMPro;

public class InfoWindow : MonoBehaviour
{
    public TMP_InputField NameField;
    public TMP_InputField AgeField;
    public TMP_InputField BioField;

    private InfoWindow infoWindow;
    private WindowsManager windowsManager;

    private void Start()
    {
        windowsManager = this.GetComponentInParent<WindowsManager>();
        infoWindow = this.GetComponent<InfoWindow>();

    }
    public void CloseWindow()
    {
        Destroy(infoWindow.gameObject);
    }
}
