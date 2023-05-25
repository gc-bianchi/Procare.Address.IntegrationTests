//-----------------------------------------------------------------------
// <copyright file="GetAddressesTests.cs" company="Procare Software, LLC">
//     Copyright © 2021-2023 Procare Software, LLC. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Procare.Address.IntegrationTests;

using System;
using System.Threading.Tasks;

using Xunit;

public class GetAddressesTests
{
    private readonly AddressService service = new AddressService(new Uri("https://address.dev-procarepay.com"));

    [Fact]
    public async Task GetAddresses_With_Owm_ShouldResultIn_OneMatchingAddress()
    {
        var result = await this.service.GetAddressesAsync(new AddressFilter { Line1 = "1 W Main St", City = "Medford", StateCode = "OR" }).ConfigureAwait(false);

        Assert.NotNull(result);
        Assert.Equal(1, result.Count);
        Assert.NotNull(result.Addresses);
        Assert.Equal(result.Count, result.Addresses!.Count);
    }

    [Fact]
    public async Task GetAddresses_With_AmbiguousAddress_ShouldResultIn_MultipleMatchingAddresses()
    {
        var result = await this.service.GetAddressesAsync(new AddressFilter { Line1 = "123 Main St", City = "Ontario", StateCode = "CA" }).ConfigureAwait(false);

        Assert.NotNull(result);
        Assert.NotNull(result.Addresses);
        Assert.True(result.Addresses?.Count > 1);
        Assert.Equal(result.Count, result.Addresses!.Count);

        var pattern = @"123\s[W|E]\sMAIN\sST";
        foreach (var address in result.Addresses)
        {
            Assert.Matches(pattern, address.Line1);
        }
    }
}
