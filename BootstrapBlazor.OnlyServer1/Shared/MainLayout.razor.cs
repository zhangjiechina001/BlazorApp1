using BootstrapBlazor.Components;

using Microsoft.AspNetCore.Components.Routing;

namespace BootstrapBlazor.OnlyServer1.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class MainLayout
    {
        private bool UseTabSet { get; set; } = false;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem>? Menus { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Menus = GetIconSideMenuItems();
            ShowFooter = false;
            UseTabSet = false;
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
                new MenuItem() { Text = "Index", Icon = "fa-solid fa-fw fa-flag", Url = "/" , Match = NavLinkMatch.All},
                new MenuItem() { Text = "Counter", Icon = "fa-solid fa-fw fa-check-square", Url = "counter" },
                new MenuItem() { Text = "FetchData", Icon = "fa-solid fa-fw fa-database", Url = "fetchdata" },
                new MenuItem() { Text = "Table", Icon = "fa-solid fa-fw fa-table", Url = "table" },
                new MenuItem() { Text = "数据查询", Icon = "fa-solid fa-fw fa-table", Url = "data-inquire" }
            };

            return menus;
        }
    }
}