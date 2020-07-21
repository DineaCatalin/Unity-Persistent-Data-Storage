using System.Collections.Generic;
using UnityEngine;

public class Game : PerisableObject {

    // Keys
    public KeyCode createKey = KeyCode.C;
    public KeyCode saveKey = KeyCode.S;
    public KeyCode loadKey = KeyCode.L;

    // Object after which the other ones are cloned
    public PerisableObject m_Prefab;

    // List of all our objects
    List<PerisableObject> m_Objects;

    // Storage
    public PersistentStorage m_Storage;

    // Save version
    private const int saveVersion = 1;


    private void Awake()
    {
        m_Objects = new List<PerisableObject>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(createKey))
        {
            CreateObject();
        }
        if (Input.GetKeyDown(saveKey))
        {
            m_Storage.Save(this);
        }
        if (Input.GetKeyDown(loadKey))
        {
            BeginGame();
            m_Storage.Load(this);
        }
    }

    void CreateObject()
    {
        // Instantiate Object
        var obj = Instantiate(m_Prefab);

        // Get reference to it's transform
        Transform trans = obj.transform;
        // Modify transform
        trans.localPosition = Random.insideUnitSphere * 5f;
        trans.localRotation = Random.rotation;
        trans.localScale = Vector3.one * Random.Range(0.1f, 1f);

        // Add it to the Object List
        m_Objects.Add(obj);
    }

    public override void Save(GameDataWriter writer)
    {
        writer.Write(-saveVersion);
        writer.Write(m_Objects.Count);

        for (int i = 0; i < m_Objects.Count; i++)
        {
            m_Objects[i].Save(writer);
        }
    }

    public override void Load(GameDataReader reader)
    {
        int version = -reader.ReadInt();
        int count = version < 0 ? -version : reader.ReadInt();

        for(int i = 0; i < count; i++)
        {
            var newObj = Instantiate(m_Prefab);
            newObj.Load(reader);
            m_Objects.Add(newObj);
        }
    }

    public void BeginGame()
    {
        foreach(PerisableObject obj in m_Objects)
        {
            Destroy(obj.gameObject);
        }
        m_Objects.Clear();
    }

}
