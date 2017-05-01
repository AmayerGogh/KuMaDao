using CaptchaGen;
using CodeCarvings.Piczard;
using CodeCarvings.Piczard.Filters.Watermarks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amayer.Utility
{
    public class Image
    {
        private ImageProcessingJob CreateJob(int imgX, int imgY)
        {
            ImageProcessingJob job = new ImageProcessingJob();
            job.Filters.Add(new FixedResizeConstraint(imgX, imgY));

            return job;

        }
        public void MiniImage2Path(string oldPath, string newPath, int imgX =200, int imgY =100)
        {
            var job = CreateJob(imgX, imgY);
            job.SaveProcessedImageToFileSystem(oldPath, newPath,new JpegFormatEncoderParams());
        }
        public void MiniImage2Path(string oldPath, int imgX = 200, int imgY = 100)
        {
            var job = CreateJob(imgX, imgY);
           
           // job.SaveProcessedImageToStream(oldPath, new ,new JpegFormatEncoderParams());
        }
        public void WaterMark() {

            ImageWatermark imgWatermark = new ImageWatermark(@"D:\a\sauce.png");
            imgWatermark.ContentAlignment = System.Drawing.ContentAlignment.BottomRight;//水印位置
            imgWatermark.Alpha = 100;//透明度，需要水印图片是背景透明的png图片
            ImageProcessingJob jobNormal = new ImageProcessingJob();
            jobNormal.Filters.Add(imgWatermark);//添加水印
            jobNormal.Filters.Add(new FixedResizeConstraint(300, 300));//限制图片的大小，避免生成大图。如果想原图大小处理，就不用加这个Filter
            jobNormal.SaveProcessedImageToFileSystem(@"D:\a\Tulips.jpg", @"D:\a\2.png");
        }
        /// <summary>
        /// 
        /// </summary>
        public void CreateValidateImage(string msg,int height=60,int width=150,int size=30,int n =10)
        {
            using (MemoryStream ms = ImageFactory.GenerateImage(msg, height, width,size, n))
            using (FileStream fs = File.OpenWrite(@"d:\1.jpg"))
            {
                ms.CopyTo(fs);
            }
            
        }


    }
}
