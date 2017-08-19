using System;
using System.Collections.Generic;
using System.Text;

namespace XCentium.Test.Utilities
{
    /// <summary>
    /// Image + Alt text (when present on target site).
    /// </summary>
    public class ImageData
    {
        /// <summary>
        /// Image source
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// Image Alt Text
        /// </summary>
        public string AltText { get; set; }
    }
}
