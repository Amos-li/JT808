﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x8500_Formatter : IJT808Formatter<JT808_0x8500>
    {
        public JT808_0x8500 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x8500 jT808_0X8500 = new JT808_0x8500
            {
                ControlFlag = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset)
            };
            readSize = offset;
            return jT808_0X8500;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x8500 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.ControlFlag);
            return offset;
        }
    }
}
