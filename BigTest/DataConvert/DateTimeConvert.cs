using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigTest.DataConvert
{
    /// <summary>
    /// 时间格式转换
    /// </summary>
    class DateTimeConvert
    {
        /// <summary>
        /// test code
        /// 格式化字符串
        /// dtNow.ToString("yyyy-MM-dd HH:mm:ss.fffffff")
        /// </summary>
        void TestCode()
        {
            DataConvert.DateTimeConvert convert = new DataConvert.DateTimeConvert();
            DateTime dtNow = DateTime.Now;
            //精确到秒
            DateTime outTime = convert.DateTimeAccurateSecond(dtNow);
            //精确到毫秒3位
            DateTime outTime2 = convert.DateTimeAccurateMilliSecond(dtNow);
            //时间转字符串，精确到毫秒3位
            string str = convert.DateTimeToString(outTime2);
            //字符串转时间
            DateTime retTime = convert.StringToDateTime(str);
        }

        /// <summary>
        /// 将时间转换位字符串
        /// 精确到毫秒,毫秒最多位数7位，不同计算机可能不同
        /// </summary>
        /// <param name="inputTime">input datetime</param>
        /// <returns></returns>
        public string DateTimeToString(DateTime inputTime)
        {
            return inputTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        /// <summary>
        /// 字符串转为时间
        /// </summary>
        /// <param name="timeStr">字符串</param>
        /// <returns></returns>
        public DateTime StringToDateTime(string timeStr)
        {
            DateTime retTime = DateTime.MinValue;
            DateTime.TryParseExact(timeStr, "yyyy-MM-dd HH:mm:ss.fff", null, System.Globalization.DateTimeStyles.AssumeLocal, out retTime);
            return retTime;
        }

        /// <summary>
        /// 时间精确到秒
        /// 移除所有毫秒数
        /// example:
        /// input：2019-06-17 21:42:17.6141009
        /// out:2019-06-17 21:42:17.0000000
        /// </summary>
        /// <param name="inputTime">input datetime</param>
        /// <returns>datetime</returns>
        public DateTime DateTimeAccurateSecond(DateTime inputTime)
        {
            return new DateTime(inputTime.Ticks - inputTime.Ticks % TimeSpan.TicksPerSecond, inputTime.Kind);
        }

        /// <summary>
        /// 时间精确到毫秒
        /// 保留3位毫秒数
        /// example:
        /// input：2019-06-17 21:42:17.6141009
        /// out:2019-06-17 21:42:17.6140000
        /// </summary>
        /// <param name="inputTime">input datetime</param>
        /// <returns>datetime</returns>
        public DateTime DateTimeAccurateMilliSecond(DateTime inputTime)
        {
            return new DateTime(inputTime.Ticks - inputTime.Ticks % TimeSpan.TicksPerMillisecond, inputTime.Kind);
        }
    }
}
