﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x0200_0x2B_Formatter : IJT808Formatter<JT808_0x0200_0x2B>
    {
        public JT808_0x0200_0x2B Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x0200_0x2B jT808LocationAttachImpl0x2B = new JT808_0x0200_0x2B
            {
                AttachInfoId = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                AttachInfoLength = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                Analog = JT808BinaryExtensions.ReadInt32Little(bytes, ref offset)
            };
            readSize = offset;
            return jT808LocationAttachImpl0x2B;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x0200_0x2B value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.AttachInfoId);
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.AttachInfoLength);
            offset += JT808BinaryExtensions.WriteInt32Little(bytes, offset, value.Analog);
            return offset;
        }
    }
}

