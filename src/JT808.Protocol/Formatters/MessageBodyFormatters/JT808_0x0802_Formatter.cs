﻿using JT808.Protocol.Extensions;
using JT808.Protocol.MessageBody;
using System;
using System.Collections.Generic;
using JT808.Protocol.Metadata;

namespace JT808.Protocol.Formatters.MessageBodyFormatters
{
    public class JT808_0x0802_Formatter : IJT808Formatter<JT808_0x0802>
    {
        public JT808_0x0802 Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config)
        {
            int offset = 0;
            JT808_0x0802 JT808_0x0802 = new JT808_0x0802
            {
                MsgNum = JT808BinaryExtensions.ReadUInt16Little(bytes, ref offset),
                MultimediaItemCount = JT808BinaryExtensions.ReadUInt16Little(bytes, ref offset),
                MultimediaSearchItems = new List<JT808MultimediaSearchProperty>()
            };
            for (var i = 0; i < JT808_0x0802.MultimediaItemCount; i++)
            {
                JT808MultimediaSearchProperty jT808MultimediaSearchProperty = new JT808MultimediaSearchProperty
                {
                    MultimediaId = JT808BinaryExtensions.ReadUInt32Little(bytes, ref offset),
                    MultimediaType = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                    ChannelId = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                    EventItemCoding = JT808BinaryExtensions.ReadByteLittle(bytes, ref offset),
                    Position = JT808FormatterExtensions.GetFormatter<JT808_0x0200>().Deserialize(bytes.Slice(offset, 28), out _, config)
                };
                offset += 28;
                JT808_0x0802.MultimediaSearchItems.Add(jT808MultimediaSearchProperty);
            }
            readSize = offset;
            return JT808_0x0802;
        }

        public int Serialize(ref byte[] bytes, int offset, JT808_0x0802 value, IJT808Config config)
        {
            offset += JT808BinaryExtensions.WriteUInt16Little(bytes, offset, value.MsgNum);
            offset += JT808BinaryExtensions.WriteUInt16Little(bytes, offset, (ushort)value.MultimediaSearchItems.Count);
            foreach (var item in value.MultimediaSearchItems)
            {
                offset += JT808BinaryExtensions.WriteUInt32Little(bytes, offset, item.MultimediaId);
                offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, item.MultimediaType);
                offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, item.ChannelId);
                offset += JT808BinaryExtensions.WriteByteLittle(bytes, offset, item.EventItemCoding);
                int positionOffset = JT808FormatterExtensions.GetFormatter<JT808_0x0200>().Serialize(ref bytes, offset, item.Position, config);
                offset += 28;
            }
            return offset;
        }
    }
}
