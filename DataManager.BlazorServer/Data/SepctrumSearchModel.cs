// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using DataManager.Database.Utils;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataManager.BlazorServer.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class SepctrumSearchModel : ITableSearchModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? WorkPosition { get; set; }

        public DateTimeRangeValue? SearchDate { get; set; }

        public List<string> Hobbys { get; set; }=new List<string>();

        public static List<string> GetAllHobbys()
        {
            return new List<string>() { "打游戏", "下棋", "编程", "踢足球" };
        }

        public IEnumerable<IFilterAction> GetSearches()
        {
            return GetSearchs();
        }

        /// <summary>
        /// 获得 搜索条件集合
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<IFilterAction> GetSearchs()
        {
            var ret = new List<IFilterAction>();
            if (!string.IsNullOrEmpty(Location)&&Location!="所有地点")
            {
                ret.Add(new SearchFilterAction(nameof(SpectrumInquireItem.Location), Location));
            }
            if (!string.IsNullOrEmpty(WorkPosition)&&WorkPosition!="所有工位")
            {
                ret.Add(new SearchFilterAction(nameof(SpectrumInquireItem.WorkLocation), WorkPosition));
            }
            if (SearchDate != null&&SearchDate.Start!=SearchDate.End)
            {
                ret.Add(new SearchFilterAction(nameof(SpectrumInquireItem.CreateTime), SearchDate.Start, FilterAction.GreaterThanOrEqual));
                ret.Add(new SearchFilterAction(nameof(SpectrumInquireItem.CreateTime), SearchDate.End, FilterAction.LessThanOrEqual));
            }
            return ret;
        }

        /// <summary>
        /// 重置操作
        /// </summary>
        public void Reset()
        {
            Location = null;
            WorkPosition = null;
            SearchDate = null;
            Hobbys.Clear();
        }

        public static List<string> GetWorkPositions(string location)
        {
            JObject obj = LoadJson();
            List<string> ret = new List<string>();
            foreach (var item in obj)
            {
                if(location==item.Key)
                {
                    ret.AddRange(item.Value.Select(t=>t.ToString()));
                }
            }
            return ret;
        }

        public static List<string> GetLocations()
        {
            JObject obj = LoadJson();
            List<string> ret = new List<string>();
            foreach (var item in obj)
            {
                ret.Add(item.Key);
            }
            return ret;
        }

        private static JObject LoadJson()
        {
            JObject obj=JsonUtils.LoadJson("SpectrumInfomation");
            return obj;
        }
    }
}
