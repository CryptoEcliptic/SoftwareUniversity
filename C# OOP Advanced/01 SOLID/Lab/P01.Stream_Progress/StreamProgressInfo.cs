using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        // If we want to stream a music file, we can't
        
        public StreamProgressInfo(IStreamable streamItem)
        {
            this.StreamItem = streamItem;
        }

        public int CalculateCurrentPercent()
        {
            return (this.StreamItem.BytesSent * 100) / this.StreamItem.Length;
        }

        public IStreamable StreamItem { get; set; }
    }
}
