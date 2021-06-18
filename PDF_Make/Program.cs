using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Make
{
    class Program
    {
        static void Main(string[] args)
        {
            //製作PDF文件
            string filename = "PDF文件";

            //文件初始化
            Document doc = new Document(PageSize.A4, 20, 20, 20, 20);//輸出尺寸設定 / 邊界設定
            MemoryStream Memory = new MemoryStream();//存放資料的記憶體資料流

            // 二. 將doc直接寫到磁碟中
            PdfWriter Pdfwrite = PdfWriter.GetInstance(doc, new FileStream("C:\\PDF\\" + filename + ".pdf", FileMode.Create));

            //字型設定                
            BaseFont bf_kaiu = BaseFont.CreateFont("c:\\windows\\fonts\\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED); //標楷體-標準
            Font ChFont_b1 = new Font(bf_kaiu, 16);    //公司名稱
            Font ChFont_b2 = new Font(bf_kaiu, 14);    //表單名稱
            Font ChFont_b3 = new Font(bf_kaiu, 12);    //內容文字
            Font ChFont_b4 = new Font(bf_kaiu, 13);    //內容文字
            Font ChFont_b5 = new Font(bf_kaiu, 10);    //內容文字

            //開始將資料寫到doc中
            doc.Open();
            
            PdfPTable table = new PdfPTable(50); //一列50行
            table.TotalWidth = 500f;
            table.LockedWidth = true;

            //第一列-空行
            PdfPCell cell_empty = new PdfPCell(new Phrase(" ", ChFont_b2));
            cell_empty.Border = Rectangle.NO_BORDER;
            cell_empty.Colspan = 50;
            //第一列- 空
            table.AddCell(cell_empty);

            
            //第二列
            PdfPCell cell = new PdfPCell(new Phrase("", ChFont_b1));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;   //將cell的文字水平置中
            cell.Border = Rectangle.NO_BORDER; //設定cell無框線
            cell.Colspan = 50;
            table.AddCell(cell);

           
            doc.Add(table);

            doc.Close();
            Pdfwrite.Close();
        }
    }
}
