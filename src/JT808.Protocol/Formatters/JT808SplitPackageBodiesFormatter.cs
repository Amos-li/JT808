﻿using JT808.Protocol.Extensions;
using System;

namespace JT808.Protocol.Formatters
{
    public class JT808SplitPackageBodiesFormatter : IJT808Formatter<JT808SplitPackageBodies>
    {
        public JT808SplitPackageBodies Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            JT808SplitPackageBodies jT808SplitPackageBodies = new JT808SplitPackageBodies
            {
                Data = bytes.ToArray()
            };
            readSize = bytes.Length;
            return jT808SplitPackageBodies;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808SplitPackageBodies value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteBytesLittle(bytes, offset, value.Data);
            return offset;
        }
    }
}
