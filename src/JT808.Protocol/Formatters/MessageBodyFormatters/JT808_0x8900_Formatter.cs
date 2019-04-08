﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using System;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x8900_Formatter : IJT808Formatter<JT808_0x8900>
    {
        public JT808_0x8900 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x8900 jT808_0X8900 = new JT808_0x8900
            {
                PassthroughType = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                PassthroughData = bytes.Slice(offset).ToArray()
            };
            readSize = offset;
            return jT808_0X8900;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x8900 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, value.PassthroughType);
            object obj = JT808FormatterExtensions.GetFormatter(value.JT808_0X8900_BodyBase.GetType());
            offset = JT808FormatterResolverExtensions.JT808DynamicSerialize(obj, ref bytes, offset, value.JT808_0X8900_BodyBase, config);
            return offset;
        }
    }
}
