using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIS
{
    class DataPoint
    {

        List<dynamic> attributes;       // {attr1, attr2, ..., attrN}   

        public DataPoint(List<dynamic> attributes)
        {
            this.attributes = attributes;
        }

        public List<dynamic> getAttributes()
        {
            return this.attributes;
        }
    }
}
