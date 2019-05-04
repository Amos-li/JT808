using JT808.Protocol.Attributes;
using JT808.Protocol.Enums;
using JT808.Protocol.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT808.Protocol.Interfaces
{
    public abstract class JT808MsgIdFactoryBase
    {
        private  Dictionary<ushort, Type> map;

        protected JT808MsgIdFactoryBase()
        {
            map = new Dictionary<ushort, Type>();
            InitMap();
        }

        public Type GetBodiesImplTypeByMsgId(ushort msgId) => map.TryGetValue(msgId, out Type type) ? type : null;


        private  void InitMap()
        {
            foreach (var item in Enum.GetNames(typeof(JT808MsgId)))
            {
                JT808MsgId msgId = item.ToEnum<JT808MsgId>();
                JT808BodiesTypeAttribute jT808BodiesTypeAttribute = msgId.GetAttribute<JT808BodiesTypeAttribute>();
                map.Add((ushort)msgId, jT808BodiesTypeAttribute?.JT808BodiesType);
            }
        }

        internal void SetMap<TJT808Bodies>(ushort msgId) where TJT808Bodies : JT808Bodies
        {
            if (!map.ContainsKey(msgId))
                map.Add(msgId, typeof(TJT808Bodies));
        }

        internal void ReplaceMap<TJT808Bodies>(ushort msgId) where TJT808Bodies : JT808Bodies
        {
            if (!map.ContainsKey(msgId))
                map.Add(msgId, typeof(TJT808Bodies));
            else
                map[msgId] = typeof(TJT808Bodies);
        }
    }
}
