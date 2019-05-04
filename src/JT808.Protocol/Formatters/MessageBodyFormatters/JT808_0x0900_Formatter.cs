﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x0900_Formatter : IJT808Formatter<JT808_0x0900>
    {
        public JT808_0x0900 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x0900 jT808_0X0900 = new JT808_0x0900
            {
                PassthroughType = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                PassthroughData = bytes.Slice(offset, bytes.Length - offset).ToArray()
            };
            readSize = bytes.Length;//读取整个数据体
            return jT808_0X0900;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x0900 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.PassthroughType);
            object obj = JT808FormatterExtensions.GetFormatter(value.JT808_0x0900_BodyBase.GetType());
            offset = JT808FormatterResolverExtensions.JT808DynamicSerialize(obj, ref bytes, offset, value.JT808_0x0900_BodyBase, config);
            return offset;
        }
    }
}
