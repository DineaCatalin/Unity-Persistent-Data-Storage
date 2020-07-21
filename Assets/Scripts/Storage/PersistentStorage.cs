using System.IO;
using UnityEngine;

public class PersistentStorage : MonoBehaviour {

    string m_SavePath;

    private void Awake()
    {
        m_SavePath = Path.Combine(Application.persistentDataPath, "saveFile");
        Debug.Log("Application savepath : " + m_SavePath);
    }

    public void Save(PerisableObject obj)
    {
        // This will safely delete writer when it is out of scope
        using (
            var writer = new BinaryWriter(File.Open(m_SavePath, FileMode.Create))
        )
        {
            obj.Save(new GameDataWriter(writer));
        }
    }

    public void Load(PerisableObject obj)
    {
        // This will safely delete reader when it is out of scope
        using (
            var reader = new BinaryReader(File.Open(m_SavePath, FileMode.Open))
        )
        {
            obj.Load(new GameDataReader(reader));
        }
    }
}
