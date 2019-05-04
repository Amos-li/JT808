﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x8103_0x0011_Formatter : IJT808Formatter<JT808_0x8103_0x0011>
    {
        public JT808_0x8103_0x0011 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x8103_0x0011 jT808_0x8103_0x0011 = new JT808_0x8103_0x0011
            {
                ParamLength = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset)
            };
            jT808_0x8103_0x0011.ParamValue = JT808BinaryExtensions.ReadStringLittle(bytes, ref offset, jT808_0x8103_0x0011.ParamLength);
            readSize = offset;
            return jT808_0x8103_0x0011;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x8103_0x0011 value, IJT808Config config)
        {
            offset += 1;
            var lenth = JT808BinaryExtensions.WriteStringLittle(bytes, offset, value.ParamValue);
            JT808BinaryExtensions.WriteByteLittle(bytes, offset - 1, (byte)lenth);
            offset += lenth;
            return offset;
        }
    }
}