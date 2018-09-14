#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo
     * 文 件 名：       Class1
     * 创建时间：       2018/9/13 17:21:03
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Apollo.Apollo;
using Abp.Apollo.Configuration;
using Abp.Modules;
using System.Reflection;

namespace Abp.Apollo
{
    public class AbpApolloModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IAbpApolloConfiguration, AbpApolloConfiguration>();
            //实现自己的ApolloSettingManager
            IocManager.Register<IApolloSettingManager, ApolloSettingManager>();
            //Configuration.ReplaceService<ISettingStore, ApolloSettingStore>();
            /// 取代Application配置的缓存项,这样Apollo更新后能同步到当前应用
            //Configuration.ReplaceService<ISettingManager, ApolloSettingManager>();
            
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
