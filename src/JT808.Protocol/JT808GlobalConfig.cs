using JT808.Protocol.Internal;
using JT808.Protocol.MessageBody;
using JT808.Protocol.Interfaces;
using System;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("JT808.Protocol.Benchmark")]
[assembly: InternalsVisibleTo("JT808.Protocol.Test")]
namespace JT808.Protocol
{
    public class JT808GlobalConfig
    {
        private static readonly Lazy<JT808GlobalConfig> instance = new Lazy<JT808GlobalConfig>(() => new JT808GlobalConfig());

        private JT808GlobalConfig()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            MsgSNDistributed = new DefaultMsgSNDistributedImpl();
            Compress = new JT808GZipCompressImpl();
            SplitPackageStrategy = new DefaultSplitPackageStrategyImpl();
            SkipCRCCode = false;
            Encoding = Encoding.GetEncoding("GBK");
        }

        public IJT808MsgSNDistributed MsgSNDistributed { get; private set; }

        public IJT808Compress Compress { get; private set; }

        public IJT808SplitPackageStrategy SplitPackageStrategy { get; private set; }

        public static JT808GlobalConfig Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public Encoding Encoding;

        /// <summary>
        /// 跳过校验码
        /// 测试的时候需要手动修改值，避免验证
        /// 默认：false
        /// </summary>
        public bool SkipCRCCode { get; private set; }

        /// <summary>
        /// 设置消息序列号
        /// </summary>
        /// <param name="msgSNDistributed"></param>
        /// <returns></returns>
        public JT808GlobalConfig SetMsgSNDistributed(IJT808MsgSNDistributed msgSNDistributed)
        {
            instance.Value.MsgSNDistributed = msgSNDistributed;
            return instance.Value;
        }

        /// <summary>
        /// 设置压缩算法
        /// 默认GZip
        /// </summary>
        /// <param name="compressImpl"></param>
        /// <returns></returns>
        public JT808GlobalConfig SetCompress(IJT808Compress compressImpl)
        {
            instance.Value.Compress = compressImpl;
            return instance.Value;
        }
        /// <summary>
        /// 设置分包算法
        /// 默认3*256
        /// </summary>
        /// <param name="splitPackageStrategy"></param>
        /// <returns></returns>
        public JT808GlobalConfig SetSplitPackageStrategy(IJT808SplitPackageStrategy splitPackageStrategy)
        {
            instance.Value.SplitPackageStrategy = splitPackageStrategy;
            return instance.Value;
        }
        /// <summary>
        /// 设置跳过校验码
        /// 场景：测试的时候，可能需要手动改数据，所以测试的时候有用
        /// </summary>
        /// <param name="skipCRCCode"></param>
        /// <returns></returns>
        public JT808GlobalConfig SetSkipCRCCode(bool skipCRCCode)
        {
            instance.Value.SkipCRCCode = skipCRCCode;
            return instance.Value;
        }
    }
}
