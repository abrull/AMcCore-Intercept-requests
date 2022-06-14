using Chorus.Conductor;
using Chorus.Conductor.Config;
using Chorus.Conductor.Database;
using Chorus.Conductor.Sync;
using Microsoft.WindowsAzure.MobileServices;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace AmcInterception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dbPath = GetDatabasePath();

            // Configure conductor
            var config = new ConductorConfiguration
            {
                DatabaseFileLocation = dbPath,
                SyncInterval = 20,
                GetServiceUriAsync = () => Task.FromResult(new Uri("http://www.123.edtr")),
                GetDbContext = (con) => new ConductorDbContext(),
                GetHttpMessageHandler = () => new MessageHandler()
            };

            // bootstrap
            var msc = new MobileServiceClientFactory(config).Create();

            MobileClientManager mcm = null;
            SyncCommandsManager scm = null;
            NoteTableTypesProvider typeProvider = new NoteTableTypesProvider(new TableTypesProvider());
            var manager = new ConductorManager(config, () => mcm = new MobileClientManager(
                 msc,
                 @"C:\Users\abrull\Downloads\test.db",
                 scm = new SyncCommandsManager(typeProvider, msc),
                 typeProvider),
                 () => new SyncManager(mcm, new SyncCommands(() => scm))
                 );

            // Initialize
            Batteries_V2.Init();
            manager.Init(Assembly.GetAssembly(typeof(Program))).GetAwaiter().GetResult(); ;

            // Sync
            manager.SyncManager.SyncAsync(CancellationToken.None).GetAwaiter().GetResult(); ;
            Console.ReadLine();
        }

        private static string GetDatabasePath()
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string dbFileName = "stuff.db";
            string absolutePath = Path.Combine(currentPath, dbFileName);
            System.Diagnostics.Debug.WriteLine(absolutePath);
            return absolutePath;
        }
    }
}
