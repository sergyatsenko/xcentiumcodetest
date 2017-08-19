using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace XCentium.Test.Utilities
{
    /// <summary>
    /// Parse HTML & extract data
    /// </summary>
    public class HtmlParser
    {
        /// <summary>
        /// Downloads page and xtracts top x words and images
        /// </summary>
        /// <param name="pageUrl">URL of the source page</param>
        /// <param name="maxWordCount">Max number of top-cound words to retrieve</param>
        /// <param name="maxImageCount">Max number of images to retrieve</param>
        /// <returns></returns>
        public HtmlPageData ExtractPageData(string pageUrl, int maxWordCount, int maxImageCount)
        {
            var web = new HtmlWeb();
            var doc = web.Load(pageUrl);

            return new HtmlPageData
            {
                Words = ExtractTopWords(doc, maxWordCount),
                Images = ExtractImages(doc, maxImageCount)
            };
        }

        /// <summary>
        /// Extracts top maxImageCount images from source document
        /// </summary>
        /// <param name="document">Source document</param>
        /// <param name="maxImageCount">Max number of images to retieve</param>
        /// <returns></returns>
        private List<ImageData> ExtractImages(HtmlDocument document, int maxImageCount)
        {
            return document.DocumentNode.Descendants("img").Take(maxImageCount)
                .Select(e => new ImageData
                {
                    Src = e.GetAttributeValue("src", null),
                    AltText = e.GetAttributeValue("alt", null)
                }).ToList();
        }

        /// <summary>
        /// Extracts top maxImageCount images from source document
        /// </summary>
        /// <param name="document">Source document</param>
        /// <param name="maxWordCount">Max number of top-count words to retrieve</param>
        /// <returns></returns>
        private Dictionary<string, int> ExtractTopWords(HtmlDocument document, int maxWordCount)
        {
            //TODO: clean up non-words/special characters
            var nodes = document.DocumentNode.SelectNodes("//*[not(self::script or self::style)]/text()[normalize-space()]");

            var wordCounts = new Dictionary<string, int>();
            foreach (string elementText in nodes.Select(n => HtmlEntity.DeEntitize(n.InnerText.ToLower()).Trim()).Where(text => text != string.Empty).ToList())
            {
                foreach (var word in elementText.Split())
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word] += 1;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
            }

            var sortedByCounts = from entry in wordCounts orderby entry.Value descending select entry;
            return sortedByCounts.Take(maxWordCount).ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
