﻿#region 版权信息
/*************************************************************************************
     * CLR 版本：       4.0.30319.42000
     * 机器名称：       DESKTOP-1RU3393
     * 命名空间：       Abp.Apollo.Apollo
     * 文 件 名：       IAbpApolloSettingManager
     * 创建时间：       2018/9/14 16:21:25
     * 作    者：       Colin
     * 说    明：       
     * 修改时间：       
     * 修 改 人：       
*************************************************************************************/
#endregion

using Abp.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abp.Apollo.Apollo
{
    public interface IApolloSettingManager
    {
        IReadOnlyList<ISettingValue> GetAllSettingValues(string @namespance);
        Task<IReadOnlyList<ISettingValue>> GetAllSettingValuesAsync(string @namespance);
        string GetSettingValue(string @namespance, string name);
        Task<string> GetSettingValueAsync(string @namespance, string name);
        ISettingValue GetSetting(string @namespance, string name);
        Task<ISettingValue> GetSettingAsync(string @namespance, string name);


    }
}
