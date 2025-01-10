using Business.Factories;
using Business.Models;

namespace Business.Tests.Factories;

public class ContactFactory_Tests
{
    [Fact]
    public void Create_ShouldReturnContactModel()
    {
        // Act
        var result = ContactFactory.Create();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactModel>(result);
    }
}
