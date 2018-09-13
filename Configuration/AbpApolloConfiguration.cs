#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Configuration
     * 文 件 名：       AbpApolloConfiguration
     * 创建时间：       2018/9/13 17:28:43
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion


using Abp.Apollo.Apollo;
using Microsoft.Extensions.Configuration;

namespace Abp.Apollo.Configuration
{
    public class AbpApolloConfiguration : IAbpApolloConfiguration
    {
        public string AbpApolloJsonFile { get; set; }
        public string AbpApolloJsonRoot { get; set; }
        public IConfiguration Configuration { get; set; }
        public AbpApolloOptions AbpApolloOption { get; set; }
        public AbpApolloConfiguration()
        {
            AbpApolloJsonFile = @"Configs\AppSettings.json";
            AbpApolloJsonRoot = "Apollo";
            AbpApolloOption = new AbpApolloOptions();
        }
    }
}
