using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace hod_back_testing.MapperFolder
{
    [TestClass]
    public class UnitTest1
    {
        public class Source
        {
            public int Value { get; set; }
        }

        public class Destination
        {
            public int Value { get; set; }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>());

            var sources = new[]
            {
                new Source { Value = 5 },
                new Source { Value = 6 },
                new Source { Value = 7 }
            };

            IMapper mapper = new Mapper(configuration);

            IEnumerable<Destination> ienumerableDest = mapper.Map<Source[], IEnumerable<Destination>>(sources);

        }
    }
}
