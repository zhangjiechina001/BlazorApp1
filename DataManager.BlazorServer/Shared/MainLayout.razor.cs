﻿using BootstrapBlazor.Components;

using Microsoft.AspNetCore.Components.Routing;

namespace DataManager.BlazorServer.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = false;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = false;

        private List<MenuItem>? Menus { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                new MenuItem() { Text = "样品数据查看", Icon = "fa-solid fa-fw fa-table", Url = "sample-inquire" }
            };

            return menus;
        }
    }
}