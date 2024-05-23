using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Core.ViewModels
{
    public class UploadProductCategory
    {
        public UploadProduct UploadProduct { get; set; }
        public Category TargetCategory { get; set; }
    }
}
