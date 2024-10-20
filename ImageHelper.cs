﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAquarium
{
    internal class ImageHelper
    {
        public ImageHelper()
        {
        }

        public Image LoadImageFromBytes(byte[] gifBytes)
        {
            var memoryStream = new MemoryStream(gifBytes);

            var originalImage = Image.FromStream(memoryStream, true, true);

            return originalImage;
        }

        public int GetGifDuration(byte[] gifBytes)
        {
            using MemoryStream ms = new MemoryStream(gifBytes);
            using (Bitmap gifImage = new Bitmap(ms))
            {
                if (!gifImage.RawFormat.Equals(ImageFormat.Gif))
                    return 0;

                int frameCount = gifImage.GetFrameCount(FrameDimension.Time);

                PropertyItem? propertyItem = gifImage.GetPropertyItem(0x5100);
                byte[] delayBytes = propertyItem?.Value ?? [];

                int totalDuration = 0;

                for (int i = 0; i < frameCount; i++)
                {
                    int frameDelay = BitConverter.ToInt32(delayBytes, i * 4);
                    totalDuration += frameDelay;
                }

                return totalDuration;
            }
        }
    }
}