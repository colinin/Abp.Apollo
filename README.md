# Abp.Apollo
Abp.Apollo

在启动项目下新建文件夹Configs(随意，不创建也行)

新增一个AppSettings.json文件

{
  "Apollo": {
    "AppId": "ApolloAppId",
    "MetaServer": "http://localhost:8080" //mateServer
  }
}

在依赖模块的PreInitialize添加如下代码


    [DependsOn(typeof(AbpApolloModule))]
    public class DomainModule : AbpModule
    {
        public override void PreInitialize()
        {
            //配置文件
            Configuration.AbpApollo().AbpApolloJsonFile = "AppSettings.json";
            //Apollo节点名称
            Configuration.AbpApollo().AbpApolloJsonRoot = "Apollo";
            Configuration.AbpApollo().AbpApolloOption.Namespances.Add("你的Apollo Namespance");
            //其他一些Apollo配置
            Configuration.Settings.Providers.Add<DomainAppSettingProvider>();
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }


暂时采用携程官方推荐的Microsoft.Extensions.Configuration，可以结合Redis的发布订阅功能建立一个ApolloRedisSettingStore
