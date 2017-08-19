using System.Collections.Generic;

namespace XCentium.Test.Utilities
{
    /// <summary>
    /// Extracted HTML Page data: images + top words
    /// </summary>
    public class HtmlPageData
    {
        /// <summary>
        /// Retrieved images
        /// </summary>
        public List<ImageData> Images { get; set; }
        /// <summary>
        /// top-count words, retrieved from source document
        /// </summary>
        public Dictionary<string, int> Words { get; set; }
    }
}
