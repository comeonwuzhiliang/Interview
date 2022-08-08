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
            // URL��ַ�ֲ���1000���ļ����棬��������ڴ��ܹ�Ϊ32G��ÿ���ļ���С��1 - 2G֮�䣬���������ǰ10��URL��
            // ��߾�ģ�� 10���ļ���������ڴ�Ϊ32K��ÿ���ļ���СΪ1-2K֮�� ���������ǰ10��URL
            string[] filePaths = Directory.GetFiles("../../../Fake/UrlFiles");

            Dictionary<string, int> urlsCount = new Dictionary<string, int>();

            foreach (string filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);
                using (FileStream fileStream = fileInfo.Open(FileMode.Open))
                {
                    byte[] buffer = new byte[1024 * 2];//�������ֽ�
                    int size = fileStream.Read(buffer, 0, buffer.Length);//��ȡ�����ֽڵ�buffer��������
                    string fileContent = Encoding.Default.GetString(buffer, 0, size);
                    string[] urls = fileContent.Split('\r');//���з��ָ�

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

                    //TODO:��������

                    Assert.False((urlsSize + urlsCountSize) / 1024.0 > 32, "�ڴ泬����32K");
                }
            }
        }

        /// <summary>
        /// ��ȡһ������ռ�õ��ڴ�
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