using CoworkingSystem.backend.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using static CoworkingSystem.backend.Modules.TipClanstva;


namespace CoworkingSystem.backend.Repositories
{
    internal interface ITipClanstvaRepo
    {

        public int Insert(TipClanstva tp);
        public List<TipClanstva> GetAll();
        public List<string> DistinctNames();
    }
}
