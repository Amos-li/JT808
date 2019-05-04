﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x0200_0x03_Formatter : IJT808Formatter<JT808_0x0200_0x03>
    {
        public JT808_0x0200_0x03 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x0200_0x03 jT808LocationAttachImpl0x03 = new JT808_0x0200_0x03
            {
                AttachInfoId = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                AttachInfoLength = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                Speed = JT808BinaryExtensions.ReadUInt16Little(bytes, ref offset)
            };
            readSize = offset;
            return jT808LocationAttachImpl0x03;
        }
        public int Serialize(ref byte[] bytes, int offset, JT808_0x0200_0x03 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.AttachInfoId);
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.AttachInfoLength);
            offset += JT808BinaryExtensions.WriteUInt16Little(bytes, offset, value.Speed);
            return offset;
        }
    }
}
