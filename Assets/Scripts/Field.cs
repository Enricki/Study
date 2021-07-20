using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Field : MonoBehaviour
{
    [SerializeField]
    private InfoWindow infoWindow;

    private WindowsManager windowsManager;
    private Canvas canvas;
    private Field field;

    private void Start()
    {
        field = this.GetComponent<Field>();
        canvas = this.GetComponentInParent<Canvas>();
        windowsManager = this.GetComponentInParent<WindowsManager>();
    }


    public void OpenBio()
    {
        InfoWindow window = Instantiate(infoWindow);
        window.transform.SetParent(canvas.transform, false);

        for (int i = 0; i < windowsManager.fields.Count; i++)
        {
            if (field == windowsManager.fields[i])
            {
                window.NameField.text = windowsManager.users[i].Name;
                window.AgeField.text = windowsManager.users[i].Age;
                window.BioField.text = windowsManager.users[i].Bio;
            }
        }
    }
}
