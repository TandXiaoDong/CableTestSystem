using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableTestManager.Model
{
    public class SelfStudyParams//行参数
    {
        public string StartInterfaceName { get; set; }

        public string EndInterfaceName { get; set; }

        /// <summary>
        /// 设备端开始接点(唯一)
        /// </summary>
        public string DevStartPoint { get; set; }

        public string StartPointOrder { get; set; }

        /// <summary>
        /// 设备端终点接点（唯一）
        /// </summary>
        public string DevEndPoint { get; set; }

        public string EndPointOrder { get; set; }

        public string TestResultVal { get; set; }

        public string TestReulst { get; set; }
    }
}
