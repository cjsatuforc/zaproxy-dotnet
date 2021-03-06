﻿using HttpArchive;
using Ploeh.AutoFixture;

namespace ZAProxy.Tests.TestUtils.FixtureSpecimenBuilders
{
    public class HarCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() => Generate(fixture));
        }

        private Har Generate(IFixture fixture)
        {
            var har = new Har()
            {
                Log = fixture.Create<Log>()
            };

            har.FixAutoGeneratedReferences();

            return har;
        }
    }
}
