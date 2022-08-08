using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using Xunit;

namespace Zack.Interview.MassData.Test
{
    public class TopUrlTest
    {
        [Fact]
        public void Top10Url()
        {
            // URL地址分布在1000个文件里面，计算机的内存总共为32G，每个文件大小在1 - 2G之间，求出访问量前10的URL。
            // 这边就模拟 10个文件，计算机内存为32K，每个文件大小为1-2K之间 求出访问量前10的URL
            string[] filePaths = Directory.GetFiles("../../../Fake/UrlFiles");

            Dictionary<string, int> urlsCount = new Dictionary<string, int>();

            foreach (string filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                using (FileStream fileStream = fileInfo.Open(FileMode.Open))
                {
                    byte[] buffer = new byte[1024 * 2];//定义两字节
                    int size = fileStream.Read(buffer, 0, buffer.Length);//读取多少字节到buffer数组里面
                    string fileContent = Encoding.Default.GetString(buffer, 0, size);
                    string[] urls = fileContent.Split('\r');//换行符分割

                    foreach (var url in urls)
                    {
                        if (urlsCount.ContainsKey(url))
                        {
                            urlsCount[url] = 0;
                        }
                        urlsCount[url] = urlsCount[url]++;
                    }

                    var urlsSize = GetObjectByte(urls);

                    var urlsCountSize = GetObjectByte(urlsCount);

                    //TODO:进行排序

                    Assert.False((urlsSize + urlsCountSize) / 1024.0 > 32, "内存超过了32K");
                }
            }
        }

        /// <summary>
        /// 获取一个对象占用的内存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static long GetObjectByte<T>(T t) where T : class
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.WriteObject(stream, t);
                return stream.Length;
            }
        }
    }
}