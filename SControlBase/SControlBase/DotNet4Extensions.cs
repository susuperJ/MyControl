using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

/************************************************************************************
    *命名空间：SControlBase
    *文件名：  DotNet4Extensions
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/13 14:47:52
    *描述： 
/************************************************************************************/

namespace SControlBase
{
    public static class DotNet4Extensions
    {
        public static async Task<T> InvokeAsync<T>(this Dispatcher dispatcher, Func<T> d)
        {
            var result = await TaskEx.Run(() => (T)dispatcher.Invoke(d));
            return result;
        }

        public static async Task InvokeAsync(this Dispatcher dispatcher, Action d)
        {
            await TaskEx.Run(() => dispatcher.Invoke(d));
        }

        public static async Task InvokeAsync(this Dispatcher dispatcher, Action d, DispatcherPriority dispatcherPriority)
        {
            await TaskEx.Run(() => dispatcher.Invoke(d, dispatcherPriority));
        }

        public static bool IsItemItsOwnContainer(this ItemsControl itemsControl, object item)
        {
            return (bool)itemsControl.GetType().GetMethod("IsItemItsOwnContainer").Invoke(itemsControl, new[] { item });
        }
    }
}
