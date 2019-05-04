﻿using JT808.Protocol.Enums;
using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x0108_Formatter : IJT808Formatter<JT808_0x0108>
    {
        public JT808_0x0108 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x0108 jT808_0X0108 = new JT808_0x0108
            {
                UpgradeType = (JT808UpgradeType)JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                UpgradeResult = (JT808UpgradeResult)JT808BinaryExtensions.ReadByteLittle(bytes, ref offset)
            };
            readSize = offset;
            return jT808_0X0108;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x0108 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.UpgradeType);
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.UpgradeResult);
            return offset;
        }
    }
}
