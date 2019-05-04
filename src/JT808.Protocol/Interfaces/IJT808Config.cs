using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Interfaces
{
    public interface IJT808Config
    {
        IJT808MsgSNDistributed MsgSNDistributed { get; set; }
        IJT808Compress Compress { get; set; }
        IJT808SplitPackageStrategy SplitPackageStrategy { get; set; }

        JT808MsgIdFactoryBase MsgIdFactory { get; set; }

        /// <summary>
        /// 统一编码
        /// </summary>
        Encoding Encoding { get; set; }
        /// <summary>
        /// 跳过校验码
        /// 测试的时候需要手动修改值，避免验证
        /// 默认：false
        /// </summary>
        bool SkipCRCCode { get; set; }
    }
}
