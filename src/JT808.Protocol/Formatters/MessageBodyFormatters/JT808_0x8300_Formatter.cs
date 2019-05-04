﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x8300_Formatter : IJT808Formatter<JT808_0x8300>
    {
        public JT808_0x8300 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x8300 jT808_0X8300 = new JT808_0x8300
            {
                TextFlag = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                TextInfo = JT808BinaryExtensions.ReadStringLittle(bytes, ref offset)
            };
            readSize = offset;
            return jT808_0X8300;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x8300 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.TextFlag);
            offset += JT808BinaryExtensions.WriteStringLittle(bytes, offset, value.TextInfo);
            return offset;
        }
    }
}
