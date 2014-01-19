using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

using Presentation.Enum;
using WebLibrary.Helper;

namespace XmutLuckV1
{
    public partial class CheckCode : System.Web.UI.Page
    {
        private UserType UserType
        {
            get
            {
                var useType = Request.QueryString["UserType"];
                return (UserType)Enum.Parse(typeof(UserType), useType);
            }
        }

        private static Random rnd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            // 验证码图片大小
            int width = 60;
            int height = 20;

            // 位图
            Bitmap img = new Bitmap(width, height);

            // 画板
            Graphics g = Graphics.FromImage(img);

            // 单色画笔（画背景色，字符串）
            Brush b;

            // 初始化为背景色（红绿蓝都在200到250之间）
            b = new SolidBrush(Color.FromArgb(rnd.Next(200, 250), rnd.Next(200, 250), rnd.Next(200, 250)));

            // 画背景
            g.FillRectangle(b, 0, 0, width, height);

            // 边框
            // g.FillRectangle(b, 0, 0, width - 1, height - 1);          

            // 画笔（画直线或曲线）（红绿蓝都在160到200之间）
            Pen p = new Pen(Color.FromArgb(rnd.Next(160, 200), rnd.Next(160, 200), rnd.Next(160, 200)));

            // 画干扰线
            for (int i = 0; i < 100; i++)
            {
                int x1 = rnd.Next(width);
                int y1 = rnd.Next(height);

                // 线条长度在 12 以内
                int x2 = x1 + rnd.Next(12);
                int y2 = y1 + rnd.Next(12);

                // 绘制两个坐标之间的连线
                // 参数：起点(x1, y1)，终点(x2, y2);
                g.DrawLine(p, x1, y1, x2, y2);
            }

            // 验证码字体
            Font f = new Font("Courier New", 16, FontStyle.Bold);

            // 验证码位置（左上角坐标）
            PointF pf;

            // 验证码
            StringBuilder sb = new StringBuilder();

            // 4 位验证码
            for (int i = 0; i < 4; i++)
            {
                // 数字验证码
                string s = rnd.Next(10).ToString();
                sb.Append(s);

                // 验证码颜色（红绿蓝都在20到130之间）
                b = new SolidBrush(Color.FromArgb(rnd.Next(20, 130), rnd.Next(20, 130), rnd.Next(20, 130)));

                // 可设置字符在图片中的位置
                pf = new PointF(13 * i, -1);
                g.DrawString(s, f, b, pf);
            }

            // 保存验证码
            CheckCodeHelper.SetCheckCode(UserType.ToString(), sb.ToString());

            // 将图片以流输出
            Response.ContentType = "image/pjpeg";
            img.Save(Response.OutputStream, ImageFormat.Jpeg);

            // 释放资源
            b.Dispose();
            g.Dispose();
            img.Dispose();

        }
    }
}