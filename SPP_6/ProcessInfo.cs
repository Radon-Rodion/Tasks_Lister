using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_6
{
    public class ProcessInfo
    {
        public string Name { get; set; }
        public string Pid { get; set; }
        public string CpuTime { get; set; }
        public string CpuUsage { get; set; }
        public string Memory { get; set; }

        public unsafe ProcessInfo(byte** fields)
        {
            this.Name = CharArrToStr(fields[0]);
            this.Pid = CharArrToStr(fields[1]);
            this.CpuTime = CharArrToStr(fields[2]);
            this.CpuUsage = CharArrToStr(fields[3]);
            this.Memory = CharArrToStr(fields[4]);
        }

        public string[] GetAllInfo()
        {
            string[] res = new string[4];
            res[0] = Name;
            res[1] = Pid;
            res[2] = CpuUsage;
            res[3] = Memory;
            return res;
        }

        private unsafe string CharArrToStr(byte* arr)
        {
            if (arr == null) return null;
            StringBuilder builder = new StringBuilder("");
            for (int i = 0; arr[i] != '\0'; i++)
            {
                builder.Append((char)arr[i]);
            }
            return builder.ToString();
        }
    }
}
