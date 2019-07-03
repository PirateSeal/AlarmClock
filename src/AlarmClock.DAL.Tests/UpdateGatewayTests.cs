using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace AlarmClock.DAL.Tests
{
    class UpdateGatewayTests
    {
        public UpdateGatewayTests() => Gateway = new UpdateGateway( TestHelpers.ConnectionString );
        private UpdateGateway Gateway { get; }

        [Test]
        public async void GetPresets()
        {
            Guid guid = Guid.Parse( "A34B4788-BC11-4F22-9CAF-9F2B7E0B0EED" );

            var r = await Gateway.UpdateClock( guid );
            Console.WriteLine(r);
        }
    }
}
