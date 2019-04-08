using JT808.Protocol.Internal;
using JT808.Protocol.MessageBody;
using System;

namespace JT808.Protocol
{
    /// <summary>
    /// 全局消息注册
    /// </summary>
    public  class JT808GlobalMsgIdRegister
    {
        /// <summary>
        /// 注册自定义定位信息附加数据
        /// </summary>
        /// <typeparam name="attachInfoId"></typeparam>
        public JT808GlobalMsgIdRegister Register_0x0200_Attach(params byte[] attachInfoId)
        {
            if (attachInfoId != null && attachInfoId.Length > 0)
            {
                foreach (var id in attachInfoId)
                {
                    if (!JT808_0x0200_CustomBodyBase.CustomAttachIds.Contains(id))
                    {
                        JT808_0x0200_CustomBodyBase.CustomAttachIds.Add(id);
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// 注册自定义设置终端参数Id
        /// <see cref="typeof(JT808.Protocol.MessageBody.JT808_0x8103_BodyBase)"/>
        /// <see cref="typeof(实现JT808_0x8103_BodyBase)"/>
        /// <returns></returns>
        public JT808GlobalMsgIdRegister Register_0x8103_ParamId(uint paramId, Type type)
        {
            JT808_0x8103_BodyBase.AddJT808_0x8103Method(paramId, type);
            return this;
        }

        /// <summary>
        /// 注册自定义消息
        /// </summary>
        /// <typeparam name="TJT808Bodies"></typeparam>
        /// <param name="msgId"></param>
        /// <returns></returns>
        public JT808GlobalMsgIdRegister Register_CustomMsgId<TJT808Bodies>(ushort customMsgId)
               where TJT808Bodies : JT808Bodies
        {
            JT808MsgIdFactory.SetMap<TJT808Bodies>(customMsgId);
            return this;
        }

        /// <summary>
        /// 注册电子运单内容实现类
        /// </summary>
        /// <typeparam name="TJT808_0x0701Body"></typeparam>
        /// <returns></returns>
        public JT808GlobalMsgIdRegister Register_JT808_0x0701Body<TJT808_0x0701Body>()
               where TJT808_0x0701Body : JT808_0x0701.JT808_0x0701Body
        {
            JT808_0x0701.JT808_0x0701Body.BodyImpl = typeof(TJT808_0x0701Body);
            return this;
        }

        /// <summary>
        /// 重写消息
        /// </summary>
        /// <typeparam name="TJT808Bodies"></typeparam>
        /// <param name="overwriteMsgId"></param>
        /// <returns></returns>
        public JT808GlobalMsgIdRegister Overwrite_MsgId<TJT808Bodies>(ushort overwriteMsgId)
               where TJT808Bodies : JT808Bodies
        {
            JT808MsgIdFactory.ReplaceMap<TJT808Bodies>(overwriteMsgId);
            return this;
        }
    }
}
