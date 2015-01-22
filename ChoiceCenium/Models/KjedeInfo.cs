using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChoiceCenium.Services;

namespace ChoiceCenium.Models
{
    public class KjedeInfo
    {
        private static List<KjedeInfoes> _kjeder;

        public static List<KjedeInfoes> GetKjedeInfo()
        {
            if (_kjeder == null)
            {
                var db = new ChoiceCenium_dbEntities();

                try
                {
                    _kjeder = db.KjedeInfoes.ToList();
                }
                catch (Exception e)
                {
                    //LogService.Register(e.Message, e.Source, e.ToString());
                    throw;
                }
            }
            return _kjeder;
        }
    }
}