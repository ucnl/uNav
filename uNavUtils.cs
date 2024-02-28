using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uNav
{
    public static class uNavUtils
    {
        public static bool IsValidIPandPort(string src, out string ipAddres, out ushort port)
        {
            bool result = false;
            ipAddres = null;
            port = 0;

            var splits = src.Split(":".ToCharArray());
            if (splits.Length == 2)
            {
                if (ushort.TryParse(splits[1], out port))
                {
                    var splits2 = splits[0].Split(".".ToCharArray());
                    if (splits2.Length == 4)
                    {
                        if (byte.TryParse(splits2[0], out _) &&
                            byte.TryParse(splits2[1], out _) &&
                            byte.TryParse(splits2[2], out _) &&
                            byte.TryParse(splits2[3], out _))
                        {
                            ipAddres = splits[0];
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        public static string[] GetSerialPortNamesExcept(string ePort)
        {
            List<string> result = new List<string>();

            var spNames = SerialPort.GetPortNames();
            foreach (var s in spNames)
            {
                if (s != ePort)
                    result.Add(s);
            }

            return result.ToArray();
        }
    }
}
