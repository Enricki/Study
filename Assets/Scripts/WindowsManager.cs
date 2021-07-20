using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [HideInInspector]
    public List<Field> fields = new List<Field>();

    [SerializeField]
    private GameObject startWindow;
    [SerializeField]
    private Canvas canvas;

    public List<User> users = new List<User>();
    private GameObject currentWindow;

    private void Start()
    {
        currentWindow = Instantiate(startWindow);
        currentWindow.SetActive(true);
        currentWindow.transform.SetParent(canvas.transform, false);
    }
}
