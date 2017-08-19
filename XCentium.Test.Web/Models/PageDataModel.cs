using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using XCentium.Test.Utilities;

namespace XCentium.Test.Web.Models
{
    /// <summary>
    /// Postback data model.
    /// Hard-coded error messages and page labels for now
    /// </summary>
    public class PageDataModel
    {
        /// <summary>
        /// URL of requested page
        /// </summary>
        [Required (ErrorMessage = "Page URL is required.")]
        [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)", ErrorMessage = "Page Url must be in correct format, staring with http(s)")]
        [Display(Name = "Page Url")]
        public string PageUrl { get; set; }

        /// <summary>
        /// Max number of images to retrieve
        /// </summary>
        [Required(ErrorMessage = "Max number of images is required.")]
        [RegularExpression(@"\d{1,50}", ErrorMessage = "Choose number between 1 and 50")]
        [Display(Name = "Max number of images to retrieve")]
        public int MaxImageCount { get; set; }

        /// <summary>
        /// Max number of top-counted words to retrieve
        /// </summary>
        [Required(ErrorMessage = "Max number of top-count words is required.")]
        [RegularExpression(@"\d{1,50}", ErrorMessage = "Choose number between 1 and 50")]
        [Display(Name = "Max number of top-count words")]
        public int MaxWordCount { get; set; }
        public HtmlPageData PageData { get; set; }
    }
}
