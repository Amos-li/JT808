﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{

    public class JT808_0x0302_Formatter : IJT808Formatter<JT808_0x0302>
    {
        public JT808_0x0302 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x0302 jT808_0X0302 = new JT808_0x0302
            {
                ReplySNo = JT808BinaryExtensions.ReadUInt16Little(bytes, ref offset),
                AnswerId = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset)
            };
            readSize = offset;
            return jT808_0X0302;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x0302 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteUInt16Little(bytes, offset, value.ReplySNo);
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.AnswerId);
            return offset;
        }
    }
}
