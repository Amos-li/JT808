﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x0301_Formatter : IJT808Formatter<JT808_0x0301>
    {
        public JT808_0x0301 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x0301 jT808_0X0301 = new JT808_0x0301
            {
                EventId = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset)
            };
            readSize = offset;
            return jT808_0X0301;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x0301 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.EventId);
            return offset;
        }
    }
}
