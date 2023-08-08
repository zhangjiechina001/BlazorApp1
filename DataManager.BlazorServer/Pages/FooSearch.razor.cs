// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using DataManager.BlazorServer.Data;

namespace DataManager.BlazorServer.Pages
{
    public partial class FooSearch
    {
        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        [NotNull]
        public SepctrumSearchModel? Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Parameter]
        public EventCallback<SepctrumSearchModel> ValueChanged { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SelectedItem> CountItems { get; } = new List<SelectedItem>()
        {
            new SelectedItem("", "全部"),
            new SelectedItem("1", "小于 30"),
            new SelectedItem("2", "大于等于 30 小于 70"),
            new SelectedItem("3", "大于等于 70 小于 100")
        };

        public List<SelectedItem> AllHobbys => SepctrumSearchModel.GetAllHobbys().Select((t,index)=>new SelectedItem(index.ToString(),t)).ToList();
    }

}
