﻿namespace TapAndScroll.Core.UploadModels
{
    public class FilterUpload
    {
        public string? Brand { get; set; }

        public decimal? Price {  get; set; }

        public float? DiscountPercent { get; set; }

        public bool? IsGaming { get; set; }

        public int? CategoryId { get; set; }

        public float? Rating { get; set; }

        public string? AdditionalParameters { get; set; }
    }
}
