using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MES练习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string 条码 = text条码.Text;
            
            string IP地址 = textIP.Text;

            string 检查结果 = "OK";

            if (string.IsNullOrEmpty(条码) || string.IsNullOrEmpty(IP地址))
            {
                lab状态.Text = "请填写完整的信息!";
                return;
            }
            


            
            string json = "{\"barcode\":\"" + 条码 + "\",\"result\":\"" + 检查结果+ "\",\"timestamp\":\"" + DateTime.Now + "\"}";

            // 4. 显示正在上传
            lab状态.Text = "正在上传中....";
            lab日志.Text = "目标IP：" + IP地址 + "，数据：" + json;

            try
            {
                // 5. 创建 HTTP 客户端
                HttpClient client = new HttpClient();

                // 6. 把 JSON 包装成 HTTP 内容
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

               
                string 完整地址 = IP地址;

                // 8. 发送 POST 请求
                HttpResponseMessage response = await client.PostAsync(完整地址, content);

                // 9. 判断返回结果
                if (response.IsSuccessStatusCode)
                {
                    string 返回内容 = await response.Content.ReadAsStringAsync();
                    lab状态.Text = "上传成功！";
                    lab日志.Text = "服务器返回：" + 返回内容;
                    lab结果.Text = "PASS";
                }
                else
                {
                    lab状态.Text = "上传失败！";
                    lab日志.Text = "状态码：" + response.StatusCode;
                    lab结果.Text = "NG";
                }
            }
            catch (Exception ex)
            {
                lab状态.Text = "网络错误！";
                lab日志.Text = "错误信息：" + ex.Message;
                lab结果.Text = "NG";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

