using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Login.Database
{
	public class SessionFactory
	{
		private static ISessionFactory _factory;
		public static ISession OpenSession()
		{
			return _factory.OpenSession();
		}

		public static void Init(string connectionString)
		{
			_factory = BuildSessionFactory(connectionString);
		}

		private static ISessionFactory BuildSessionFactory(string connectionString)
		{
			return Fluently.Configure()
					.Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
					.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
					.BuildSessionFactory();
		}
	}

}
