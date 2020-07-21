using System.IO;
using UnityEngine;

public class GameDataWriter
{

    BinaryWriter m_Writer;


    public GameDataWriter(BinaryWriter writer)
    {
        m_Writer = writer;
    }

	public void Write(float toWrite)
    {
        m_Writer.Write(toWrite);
    }

    public void Write(int toWrite)
    {
        m_Writer.Write(toWrite);
    }

    public void Write(Vector3 vec)
    {
        m_Writer.Write(vec.x);
        m_Writer.Write(vec.y);
        m_Writer.Write(vec.z);
    }

    public void Write(Quaternion quat)
    {
        m_Writer.Write(quat.x);
        m_Writer.Write(quat.y);
        m_Writer.Write(quat.z);
        m_Writer.Write(quat.w);
    }
}
