﻿using JT808.Protocol.Enums;
using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x0200_0x12_Formatter : IJT808Formatter<JT808_0x0200_0x12>
    {
        public JT808_0x0200_0x12 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x0200_0x12 jT808LocationAttachImpl0x12 = new JT808_0x0200_0x12
            {
                AttachInfoId = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                AttachInfoLength = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                JT808PositionType = (JT808PositionType)JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                AreaId = JT808BinaryExtensions.ReadInt32Little(bytes, ref offset),
                Direction = (JT808DirectionType)JT808BinaryExtensions.ReadByteLittle(bytes, ref offset)
            };
            readSize = offset;
            return jT808LocationAttachImpl0x12;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x0200_0x12 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.AttachInfoId);
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.AttachInfoLength);
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.JT808PositionType);
            offset += JT808BinaryExtensions.WriteInt32Little(bytes, offset, value.AreaId);
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.Direction);
            return offset;
        }
    }
}
