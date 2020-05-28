using System;
using System.Linq;
using URLPerformanceTester.Infrastructure;
using URLPerformanceTester.Models.Abstract;
using URLPerformanceTester.Models.Entities;

namespace URLPerformanceTester.Models.Concrete
{
    public class SitemapBackgroundTester : ISitemapBackgroundTester
    {
        private readonly IGenericRepository<RequestTestSet> _sitemapTestsRepo;
        private readonly IUrlTester _urlTester;
        private readonly IApproximativeModeAlgorithm _modeAlgorithm;
        private readonly ISitemapDeterminant _sitemapDeterminant;

        public SitemapBackgroundTester(IGenericRepository<RequestTestSet> sitemapTestsRepo, IUrlTester urlTesterTester,
            IApproximativeModeAlgorithm modeAlgorithm, ISitemapDeterminant sitemapDeterminant)
        {
            _sitemapTestsRepo = sitemapTestsRepo;
            _urlTester = urlTesterTester;
            _modeAlgorithm = modeAlgorithm;
            _sitemapDeterminant = sitemapDeterminant;
        }

        public void Perform(Uri uri, int sitemapTestId)
        {
            var sitemapUrLs = _sitemapDeterminant.DeterminateSitemap(uri);
            var sitemapTest = _sitemapTestsRepo.FindBy(t => t.Id == sitemapTestId).First();
            sitemapTest.UrLsCount = sitemapUrLs.Count();
            if (sitemapTest.UrlTests.Any()) sitemapTest.UrlTests.Clear();
            _sitemapTestsRepo.Save();
            var minTime = 0;
            var maxTime = 0;
            RequestTest urlTest;
            var dataPortion = 0;
            var dataPortionSize = AppSettings.BackgroudTesterDataPortionSize;
            foreach (var url in sitemapUrLs)
            {
                urlTest = _urlTester.Test(url);
                if (urlTest.Time > 0)
                {
                    if (urlTest.Time > maxTime) maxTime = urlTest.Time;
                    if (urlTest.Time < minTime || minTime == 0) minTime = urlTest.Time;
                }

                sitemapTest.UrlTests.Add(urlTest);
                dataPortion++;
                if (dataPortion == dataPortionSize)
                {
                    _sitemapTestsRepo.Save();
                    dataPortion = 0;
                }
            }
            sitemapTest.MinTime = minTime;
            sitemapTest.MaxTime = maxTime;
            sitemapTest.ModeTime = _modeAlgorithm.Mode(sitemapTest.UrlTests.Select(t => t.Time).Where(t => t != 0), 10);
            _sitemapTestsRepo.Save();
        }
    }
}