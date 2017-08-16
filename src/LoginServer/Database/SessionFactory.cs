using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Melia.Shared.Util;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Database
{
	public class SessionFactory
	{
		private static ISessionFactory _factory;
		private static Configuration _configuration;
		public static ISession OpenSession()
		{
			return _factory.OpenSession();
		}

		public static void Init(string connectionString)
		{
			_factory = BuildSessionFactory(connectionString);
		}

		public static void ExportSchema(string filepath)
		{
			if (_configuration == null)
				throw new Exception("Error. The configuration has not been initialized.");

			var sw = new StreamWriter(filepath);
			sw.Close();
			
				new SchemaExport(_configuration)
					.SetOutputFile(filepath)
					.SetDelimiter(";")
					.Create(sw, false);	
		}

		private static ISessionFactory BuildSessionFactory(string connectionString)
		{
			try
			{
				_configuration = Fluently.Configure()
					.Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
					.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
					.BuildConfiguration();
				
				return _configuration.BuildSessionFactory();
			} catch (Exception e)
			{
				Log.Error("Error. Configuration of NHibernate failed.");
				Log.Error(e.Message, e.TargetSite, e.StackTrace);

				if (e.InnerException != null)
				{
					Log.Error(e.InnerException.Message);
				}
			}
			return null;
		}
	}
}
