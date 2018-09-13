#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Apollo
     * 文 件 名：       ApolloSettingStore
     * 创建时间：       2018/9/13 17:32:55
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Apollo.Configuration;
using Abp.Apollo.Configuration.Startup;
using Abp.Configuration;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Core;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abp.Apollo.Apollo
{
    public class ApolloSettingStore : ISettingStore
    {
        private readonly IAbpApolloConfiguration _apolloConfiguration;
        public ApolloSettingStore(IAbpApolloConfiguration apolloConfiguration)
        {
            _apolloConfiguration = apolloConfiguration;
            InitiazeConfiguration(_apolloConfiguration);
        }

        public Task CreateAsync(SettingInfo setting)
        {
            return Task.FromResult(0);
        }

        public Task DeleteAsync(SettingInfo setting)
        {
            return Task.FromResult(0);
        }

        public Task<List<SettingInfo>> GetAllListAsync(int? tenantId, long? userId)
        {
            return Task.FromResult(GetAllList(tenantId, userId));
        }

        public Task<SettingInfo> GetSettingOrNullAsync(int? tenantId, long? userId, string name)
        {
            return Task.FromResult(GetSettingOrNull(tenantId, userId, name));
        }

        public Task UpdateAsync(SettingInfo setting)
        {
            return Task.FromResult(0);
        }

        private SettingInfo GetSettingOrNull(int? tenantId, long? userId, string name)
        {
            var value = _apolloConfiguration.Configuration.GetValue(name, "");
            if (!string.IsNullOrWhiteSpace(value))
            {
                return new SettingInfo
                {
                    TenantId = tenantId,
                    UserId = userId,
                    Name = name,
                    Value = value
                };
            }

            return null;
        }

        private List<SettingInfo> GetAllList(int? tenantId, long? userId)
        {
            var settingInfos = new List<SettingInfo>();
            foreach (var config in _apolloConfiguration.Configuration.AsEnumerable())
            {
                settingInfos.Add(new SettingInfo
                {
                    TenantId = tenantId,
                    UserId = userId,
                    Name = config.Key,
                    Value = config.Value
                });
            }
            return settingInfos;
        }

        #region 初始化
        private void InitiazeConfiguration(IAbpApolloConfiguration apolloConfiguration)
        {
            var builder = new ConfigurationBuilder();
            var configurations = new List<IConfiguration>();
            var apolloBuilder = builder
                .AddJsonFile(apolloConfiguration.AbpApolloJsonFile)
                .AddApollo(builder.Build().GetSection(apolloConfiguration.AbpApolloJsonRoot))
                .AddNamespace(ConfigConsts.NamespaceApplication, apolloConfiguration)
                ;
            if (apolloConfiguration.AbpApolloOption.AddInMemory)
            {
                if (apolloConfiguration.AbpApolloOption.InitialData.Count() > 0)
                {
                    apolloBuilder.AddInMemoryCollection(apolloConfiguration.AbpApolloOption.InitialData);
                }
                else
                {
                    apolloBuilder.AddInMemoryCollection();
                }
            }

            if (apolloConfiguration.AbpApolloOption.Configuration != null)
            {
                apolloBuilder.AddConfiguration(apolloConfiguration.AbpApolloOption.Configuration);
            }

            foreach (var namespance in apolloConfiguration.AbpApolloOption.Namespances)
            {
                apolloBuilder.AddNamespace(namespance, apolloConfiguration);
            }

            _apolloConfiguration.Configuration = apolloBuilder.Build();
        }
        #endregion
    }
}
