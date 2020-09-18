using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ListUnion
    {
        public List<string> listUnion(Dictionary<string, string[]> synonymousList)
        {
            List<string> unionList = new List<string>();

            foreach (KeyValuePair<String, string[]> item in synonymousList)
            {
                List<string> positionList = new List<string>();
                foreach (var item_2 in item.Value)
                {
                    positionList.Add(item_2);
                }

                unionList = unionList.Union(positionList).ToList();
            }

            return unionList;
        }
    }
}
