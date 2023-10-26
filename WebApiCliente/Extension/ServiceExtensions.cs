using Contracts;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repository;

namespace WebApiCliente.Extension
{
    //Ela consiste em nossos métodos de extensão de serviço
    public static class ServiceExtensions
    {
        /// <summary>
        /// Estamos usando as configurações básicas para adicionar a política CORS porque 
        /// para este projeto permitir qualquer origem, método e cabeçalho é suficiente. 
        /// Mas podemos ser mais restritivos com essas configurações, se quisermos . Em vez do  
        /// AllowAnyOrigin() método que permite solicitações de qualquer fonte,  poderíamos usar 
        /// o WithOrigins("http://www.something.com") método que permitirá solicitações apenas da 
        /// fonte especificada.  Além disso, em vez de  AllowAnyMethod() permitir todos os métodos 
        /// HTTP,  podemos usar WithMethods("POST", "GET") isso permitirá apenas métodos 
        /// HTTP especificados. Além disso, podemos fazer as mesmas alterações no AllowAnyHeader()
        /// método usando, por exemplo, o  WithHeaders("accept", "content-type") método para 
        /// permitir apenas cabeçalhos especificados.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        /// <summary>
        /// Além disso, precisamos configurar uma integração do IIS que nos ajudará na implantação do IIS. 
        /// Não inicializamos nenhuma das propriedades dentro das opções porque estamos bem com os valores padrão. 
        /// Para mais informações sobre essas propriedades
        /// </summary>
        /// <param name="services"></param>

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }
       
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString,
                MySqlServerVersion.LatestSupportedServerVersion));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
