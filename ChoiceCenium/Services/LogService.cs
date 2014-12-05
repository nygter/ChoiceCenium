using System;

namespace ChoiceCenium.Services
{
    public static class LogService
    {
        public static void Register(string message, string source, string complete)
        {
            var db = new ChoiceCenium_dbEntities();
            var t = DateTime.UtcNow;
            db.Logs.Add(new Logs
            {
                ExceptionMessage = message,
                Source = source,
                Complete = complete,
                LogDate = t
            });

            db.SaveChanges();
        }
    }
}