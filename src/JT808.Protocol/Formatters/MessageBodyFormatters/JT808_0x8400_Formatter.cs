﻿using JT808.Protocol.Enums;
using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x8400_Formatter : IJT808Formatter<JT808_0x8400>
    {
        public JT808_0x8400 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x8400 jT808_0X8400 = new JT808_0x8400
            {
                CallBack = (JT808CallBackType)JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                // 最长为 20 字节
                PhoneNumber = JT808BinaryExtensions.ReadStringLittle(bytes, ref offset)
            };
            readSize = offset;
            return jT808_0X8400;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x8400 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, (byte)value.CallBack);
            offset += JT808BinaryExtensions.WriteStringLittle(bytes, offset, value.PhoneNumber);
            return offset;
        }
    }
}
