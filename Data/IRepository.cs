using System.Collections.Generic;
using A7_ImplementingInterfaces.Models;

namespace A7_ImplementingInterfaces 
{
    interface IRepository
    {
        List<Media> getMediaList(int mediaCode);
        string getName();

        void viewAll(int mediaCode);

        void searchById(int mediaCode);

        void writeData(List<string> media, string strPath);

        int getLineNum(int mediaCode);
    }
}