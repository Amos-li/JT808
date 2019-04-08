﻿using System;

namespace JT808.Protocol.Formatters
{
    public interface IJT808Formatter<T>
    {
        T Deserialize(ReadOnlySpan<byte> bytes, out int readSize, IJT808Config config);

        int Serialize(ref byte[] bytes, int offset, T value, IJT808Config config);
    }
}
