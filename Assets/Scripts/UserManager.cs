using UnityEngine;
using TMPro;
using System.IO;

public struct User
{
    public string Name;
    public string Age;
    public string Bio;

    public User(string name, string age, string bio)
    {
        Name = name;
        Age = age;
        Bio = bio;
    }
}
public class UserManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField nameField;
    [SerializeField]
    private TMP_InputField ageField;
    [SerializeField]
    private TMP_InputField bioField;
    [SerializeField]
    private Field field;
    [SerializeField]
    private RectTransform listContent;

    private WindowsManager windowsManager;
    private string path;


    private void Start()
    {
        windowsManager = this.GetComponentInParent<WindowsManager>();
        path = Path.Combine(Application.persistentDataPath, "users.dat");
    }
    public void AddUser()
    {
        if (nameField.text != string.Empty && ageField.text != string.Empty && bioField.text != string.Empty)
        {
            windowsManager.users.Add(new User(nameField.text, ageField.text, bioField.text));
            FillList();
        }
    }

    public void FillList()
    {
        Field item = Instantiate(field);
        item.transform.SetParent(listContent, false);
        item.GetComponentInChildren<TMP_Text>().text = nameField.text + ": " + ageField.text + " years";
        windowsManager.fields.Add(item);
        nameField.text = null;
        ageField.text = null;
        bioField.text = null;
    }


    private void SaveStruct(BinaryWriter writer)
    {
        writer.Write(windowsManager.users.Count);
        for (int i = 0; i < windowsManager.users.Count; i++)
        {
            writer.Write(windowsManager.users[i].Name);
            writer.Write(windowsManager.users[i].Age);
            writer.Write(windowsManager.users[i].Bio);
        }
    }

    private void LoadStruct(BinaryReader reader)
    {
        windowsManager.users.Clear();
        windowsManager.fields.Clear();
        int usersCount = reader.ReadInt32();

        for (int i = 0; i < usersCount; i++)
        {
            string name = reader.ReadString();
            string age = reader.ReadString();
            string bio = reader.ReadString();

            windowsManager.users.Add(new User(name, age, bio));

            Field item = Instantiate(field);
            item.transform.SetParent(listContent, false);
            item.GetComponentInChildren<TMP_Text>().text = windowsManager.users[i].Name + ": " + windowsManager.users[i].Age + " years";
            windowsManager.fields.Add(item);
        }
    }

    public void ClearList()
    {
        windowsManager.users.Clear();

        nameField.text = null;
        ageField.text = null;
        bioField.text = null;

        for(int i = 0; i < listContent.transform.childCount; i ++)
        {
            Destroy(listContent.GetChild(i).gameObject);
        }
    }

    public void SaveList()
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            SaveStruct(writer);
        }
    }

    public void LoadList()
    {
        if (!File.Exists(path))
        {
            Debug.LogError("File does not exist" + path);
            return;
        }
        using (BinaryReader reader = new BinaryReader(File.OpenRead(path)))
        {
            LoadStruct(reader);
        }
    }

}
