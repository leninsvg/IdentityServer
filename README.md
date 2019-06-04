# IdentityServer


## Tips

#### Configuracion resource owner sin SSL

```
var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
{
    Address = "http://identityserver",
    Policy =
    {
        ValidateIssuerName = false,
        RequireHttps = false
    }
});

```

### Configuracion Migrations IdentityServer

#### Generacion Migracion Inicial (Requisito en Startup.cs)

**Startup.cs**
```
string connectionString = configuration.GetSection("connectionString").Value;
string migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = buider =>
            buider.UseSqlServer(connectionString, 
                sql => sql.MigrationsAssembly(migrationAssembly));     
    })
    //Operation Store: tokens, consents, codes, etc
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = builder =>
            builder.UseSqlServer(connectionString,
                sql => sql.MigrationsAssembly(migrationAssembly));
    })
    .AddTestUsers(Config.GetUsers());                
```

#### Nuget Package command line

##### Generacion migracion inicial

```
Add-Migration InitialIS4PersistedGrantDBMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
```

##### Configuracion inicial migraciones

```
Add-Migration InitialIS4ConfigurationDBMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
```
