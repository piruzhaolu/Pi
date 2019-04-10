using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;

namespace Pi
{
    public static class BinaryWriterExt
    {
        public static void Write(this BinaryWriter bw, int3 value)
        {
            bw.Write(value.x);
            bw.Write(value.y);
            bw.Write(value.z);
        }

        public static void Write(this BinaryWriter bw, float3 value)
        {
            bw.Write(value.x);
            bw.Write(value.y);
            bw.Write(value.z);
        }


        public static void Write(this BinaryWriter bw, float4 value)
        {
            bw.Write(value.x);
            bw.Write(value.y);
            bw.Write(value.z);
            bw.Write(value.w);
        }
    }

    public static class BinaryReaderExt
    {
        public static int3 ReadInt3(this BinaryReader br)
        {
            return new int3(br.ReadInt32(), br.ReadInt32(), br.ReadInt32());
        }

        public static float3 ReadFloat3(this BinaryReader br)
        {
            return new float3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
        }

        public static float4 ReadFloat4(this BinaryReader br)
        {
            return new float4(br.ReadSingle(), br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
        }

    }
}
