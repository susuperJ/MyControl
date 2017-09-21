using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

/************************************************************************************
    *命名空间：SControlBase
    *文件名：  NotEmptyValidationRules
    *创建人：  slj
    *电子邮箱：sulijiangline@gmail.com
    *创建时间：2017/09/14 9:37:58
    *描述： 
/************************************************************************************/

namespace SControlBase
{
    public class NotEmptyValidationRules:ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString()) ? new ValidationResult(false, "不能为空") : ValidationResult.ValidResult;
        }
    }
}
