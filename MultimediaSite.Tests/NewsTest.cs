using MultimediaSite.Core.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections.Generic;
using MultimediaSite.Contracts;

namespace MultimediaSite.Tests
{
    [TestClass]
    public class NewsTest
    {
        private List<NewsDTO> newsList;
        private Mock<INewsBL> _newsBlMock;

        [TestInitialize]
        public void Initialize()
        {
            newsList = new List<NewsDTO>()
            {
                new NewsDTO() {
                    Headline = "The Week in Business: Jobs Added, but at a Slower Pace",
                    Content = @"Happy Labor Day weekend! I hope you are enjoying some rest, even if it’s just a staycation. Here’s the business and tech news you need to know for the (short!) week ahead. — Gillian Friedman <br /><br /> <strong> What’s Up ? (Aug. 30 - Sept. 5)</ strong >< br />< br /> Jobs Report Reflects Slowing Economic Recovery < br />< br /> 
                        The United States added 1.4 million jobs in August, as employers continued to bring back workers but at a slower pace from the 1.7 million jobs added in July and down significantly from the additional 4.8 million jobs in June.And while the unemployment rate fell to 8.4 percent, from 10.2 percent in July, payrolls are still more than 11 million jobs below their pre - pandemic level.The jobs report on Friday provided some of the first data on the state of the economy as emergency federal spending, including the $600 weekly supplement to unemployment benefits, came to an end. But because the data was collected early in August, economists warn that it may not reflect the full impact of the loss of those benefits. Still, the relatively strong jobs report could ease pressure on Congress to agree on a new stimulus bill. < br />< br /> ",
                    ContentType = "article",
                    EmbedCode = null,
                    NewsDate = new DateTime(2020, 9, 6),
                    PublishedDate = new DateTime(2020, 9, 7),
                    SourceName = "New York Times",
                    SourceUrl = "https://www.nytimes.com/2020/09/06/business/the-week-in-business-jobs-economy-markets.html",
                    ImageFileName = "nyt_jobs.jpg"
                },
                new NewsDTO() {
                    Headline = "Democrats Belatedly Launch Operation to Share Information on Voters",
                    Content = @"Democrats have been far behind Republicans on compiling and sharing information that can be used by campaigns, state parties and super PACs. WASHINGTON — When Hillary Clinton lost the 2016 election, she blamed Russian interference and the former F.B.I. director James Comey’s eleventh-hour resurrection of her emails for her defeat.
                                But she also lashed out at something that got far fewer headlines: the Democratic National Committee’s failure to keep up with Republicans in the data arms race.
                                Now, with less than two months remaining before the 2020 election, the party has started the Democratic Data Exchange, a legally independent entity that allows campaigns, state parties, super PACs and other independent groups that are forbidden to coordinate with each other to share information on individual voters.
                                Democratic officials involved in the new data program say the system will help them narrow what had been a yawning gap between their party and Republicans, who started a similar independent data operation ahead of the 2016 election. Campaigns and supportive independent groups will now have a full, and nearly real-time, view into which voters have been contacted by other Democratic organizations and how those voters feel about candidates. 
                                Access to that information can be critical, particularly in battleground states, where the contest between President Trump and former Vice President Joseph R. Biden Jr. is expected to be close. In Michigan, Pennsylvania and Wisconsin — the three states that swung the 2016 election to Mr. Trump — the president won by a total of just 77,000 votes.
                                Along with the 50 state parties and the Democratic National Committee, the exchange includes several dozen Democratic outside groups and super PACs, including Priorities USA, Senate Majority PAC, House Majority PAC, Emily’s List, major labor and environmental organizations and Everytown for Gun Safety, the gun-control group that is largely funded by Michael R. Bloomberg.",
                    ContentType = "article",
                    EmbedCode = null,
                    NewsDate = new DateTime(2020, 9, 6),
                    PublishedDate = new DateTime(2020, 9, 7),
                    SourceName = "New York Times",
                    SourceUrl = "https://www.nytimes.com/2020/09/06/us/politics/Presidential-election-voting-Democrats.html",
                    ImageFileName = "dems-hillary.jpg"
                }
            };
        }

        [TestMethod]
        public void TestNews_GetResults()
        {
            //Arrange
            _newsBlMock = new Mock<INewsBL>();
            _newsBlMock.Setup(x => x.GetNewsList(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns((int p, int x, string y) => newsList);

            //Act
            var result = _newsBlMock.Object.GetNewsList(1, 1, "test url");

            //Assert
            //Should return a list
            Assert.IsTrue(result.Count > 1);
            //Headlines should not be null
            Assert.IsNotNull(result[0].Headline);
            //Content should not be null if Content Type is article or custom
            Assert.IsNotNull((result[1].ContentType == "article" || result[1].ContentType == "custom") ? result[1].Content : null);
        }
    }
}
