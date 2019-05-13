using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ClientDNS
{
    public class ReponseQuery
    {
        public byte[] receviedBytes;
        public string name;
        public int nameLength;
        public int labelsCount;
        public QueryType type;
        public QueryClass clas;
        public int skiplength;

        public ReponseQuery(byte[] receviedBytes)
        {           
            this.receviedBytes = receviedBytes;
            name = GetName();
            nameLength = GetNameLength();
            labelsCount = GetLabelsCount();
            type = GetQueryType();
            clas = GetQueryClass();
            skiplength = GetNameLength() + 6;
        }

        public string GetName()
        {
            IEnumerable<byte> a = receviedBytes.TakeWhile(l => l != 0);
            string name = "";
            while (a.Count() > 1)
            {
                name = string.Concat(name, GetLabel(ref a))+".";                
            }
            return name.TrimEnd('.');
        }

        public string GetLabel(ref IEnumerable<byte> name)
        {
            var result = name.Skip(1).Take(name.ElementAt(0));
            name = name.TakeLast(name.Count() - result.Count() - 1);
            return Encoding.ASCII.GetString(result.ToArray());
        }

        public int GetNameLength()
        {
            return GetName().Length;
        }

        public int GetLabelsCount()
        {
            return GetName().Split('.').Length;
        }

        public QueryType GetQueryType()
        {
            return (QueryType)BitConverter.ToInt16(receviedBytes.Skip(GetNameLength() + 2).Take(2).Reverse().ToArray());
        }

        public QueryClass GetQueryClass()
        {
            return (QueryClass)BitConverter.ToInt16(receviedBytes.Skip(GetNameLength() + 4).Take(2).Reverse().ToArray());
        }
    }
}
