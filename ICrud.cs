using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace proverka324
{
    internal interface ICrud
    {
        void Create(string role, string name );
        void Read(int pos, string role, string name);
        void Update(int poos, int pos, string role);
        void Delete(int pos, string role);
    }
}