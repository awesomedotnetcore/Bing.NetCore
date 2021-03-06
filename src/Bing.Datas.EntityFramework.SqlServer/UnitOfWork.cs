﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Bing.Datas.EntityFramework.Core;
using Bing.Datas.UnitOfWorks;
using Bing.Utils.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Bing.Datas.EntityFramework.SqlServer
{
    /// <summary>
    /// SqlServer 工作单元
    /// </summary>
    public abstract class UnitOfWork : UnitOfWorkBase
    {
        /// <summary>
        /// 初始化一个<see cref="UnitOfWork"/>类型的实例
        /// </summary>
        /// <param name="options">配置</param>
        /// <param name="manager">工作单元管理器</param>
        protected UnitOfWork(DbContextOptions options, IUnitOfWorkManager manager) : base(options, manager)
        {
        }

        /// <summary>
        /// 获取映射接口类型
        /// </summary>
        /// <returns></returns>
        protected override Type GetMapType()
        {
            return typeof(IMap);
        }

        /// <summary>
        /// 获取映射实例列表
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <returns></returns>
        protected override IEnumerable<Core.IMap> GetMapInstances(Assembly assembly)
        {
            return Reflection.GetInstancesByInterface<IMap>(assembly);
        }

    }
}
