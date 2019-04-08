﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x0102_Formatter : IJT808Formatter<JT808_0x0102>
    {
        public JT808_0x0102 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x0102 jT808_0X0102 = new JT808_0x0102
            {
                Code = JT808BinaryExtensions.ReadStringLittle(bytes, ref offset)
            };
            readSize = offset;
            return jT808_0X0102;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x0102 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteStringLittle(bytes, offset, value.Code);
            return offset;
        }
    }
}
