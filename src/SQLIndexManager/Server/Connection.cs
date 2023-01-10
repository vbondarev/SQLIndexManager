﻿using System.Data.SqlClient;

namespace SQLIndexManager {

  public static class Connection {

    private static string GetConnectionString(Host host, string database) {

      SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder() {
        ApplicationName = AppInfo.ApplicationName,
        ConnectTimeout = Settings.Options.ConnectionTimeout,
        DataSource = host.Server,
        InitialCatalog = database ?? "master"
      };

      if (host.AuthType == AuthTypes.Windows) {
        builder.IntegratedSecurity = true;
      }
      else {
        builder.UserID = host.User;
        builder.Password = host.Password ?? string.Empty;
      }

      return builder.ConnectionString;
    }

    public static SqlConnection Create(Host host, string database = null) {
      string connectionString = GetConnectionString(host, database);
      return new SqlConnection(connectionString);
    }

  }
  
}
