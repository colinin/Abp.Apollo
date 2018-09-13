#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Configuration.Startup
     * 文 件 名：       AbpApolloConfigurationExtensions
     * 创建时间：       2018/9/13 17:30:55
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Apollo.Apollo;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Com.Ctrip.Framework.Apollo;

namespace Abp.Apollo.Configuration.Startup
{
    public static class AbpApolloConfigurationExtensions
    {
        public static IAbpApolloConfiguration AbpApollo(this IAbpStartupConfiguration configuration)
        {
            return configuration.Get<IAbpApolloConfiguration>();
        }
        public static IApolloConfigurationBuilder AddNamespace(this IApolloConfigurationBuilder builder, string @namespance, IAbpApolloConfiguration configuration)
        {
            var apolloBuilder =  builder.AddNamespace(@namespance);
            apolloBuilder.ConfigRepositoryFactory
                .GetConfigRepository(@namespance)
                .AddChangeListener(new RepositoryChangeListener(configuration));
            return apolloBuilder;
        }
    }
}
