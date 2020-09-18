using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ListIntersection
    {
        public List<string> listIntersection(List<List<string>> synonymousList)
        {
            List<string> intersectionList = new List<string>();
            intersectionList = synonymousList[0]; // Inicialização do vetor com uma linha de valores validos

            foreach (var item in synonymousList)
            {
                List<string> positionList = new List<string>();

                foreach (var item_2 in item)
                {
                    positionList.Add(item_2);
                }

                intersectionList = intersectionList.Intersect(positionList).ToList();
            }

            return intersectionList;
        }
    }
}
