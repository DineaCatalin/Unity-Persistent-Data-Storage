using UnityEngine;
using System.IO;

public class GameDataReader
{

    BinaryReader m_Reader;

    public GameDataReader(BinaryReader reader)
    {
        m_Reader = reader;
    }

    public float ReadFloat()
    {
        return m_Reader.ReadSingle();
    }

    public int ReadInt()
    {
        return m_Reader.ReadInt32();
    }

    public Quaternion ReadQuaternion()
    {
        Quaternion quat = new Quaternion();
        quat.x = ReadFloat();
        quat.y = ReadFloat();
        quat.z = ReadFloat();
        quat.w = ReadFloat();
        return quat;
    }

    public Vector3 ReadVector3()
    {
        Vector3 vec = new Vector3();
        vec.x = ReadFloat();
        vec.y = ReadFloat();
        vec.z = ReadFloat();
        return vec;
    }
}
