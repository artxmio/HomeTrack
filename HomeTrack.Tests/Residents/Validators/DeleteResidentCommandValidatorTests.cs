using HomeTrack.Application.Residents.Commands.DeleteResident;

namespace HomeTrack.IntegrationTests.Residents.Validators;

public class DeleteResidentCommandValidatorTests
{
    #region Data
    public static TheoryData<string> ValidData =>
        new()
        {
            { "3f29b7f8-5a2b-4a7d-b14e-f23c18ec9f1d" },
            { "c83a1b2c-4d9f-4f3f-9a5a-6acb2f4e7e3b" },
            { "a19d6612-2816-49dd-bb8e-0d35e27f0f14" },
        };

    public static TheoryData<string, string[]> InvalidData =>
        new()
        {
            { "00000000-0000-0000-0000-000000000000", new[] { "Id" } },
        };
    #endregion

    [Theory]
    [MemberData(nameof(ValidData))]
    public void DeleteResidentCommandValidator_ValidData(string stringGuid)
    {
        //Arrange
        var validator = new DeleteResidentCommandValidator();
        var command = new DeleteResidentCommand()
        {
            Id = Guid.Parse(stringGuid),
        };

        //Act
        var result = validator.Validate(command);

        //Assert
        Assert.True(result.IsValid);
    }

    [Theory]
    [MemberData(nameof(InvalidData))]
    public void DeleteResidentCommandValidator_InvalidData(
        string stringGuid, 
        string[] expectedProps
    )
    {
        //Arrange
        var validator = new DeleteResidentCommandValidator();
        var command = new DeleteResidentCommand()
        {
            Id = Guid.Parse(stringGuid)
        };

        //Act
        var result = validator.Validate(command);

        //Assert
        Assert.False(result.IsValid);

        foreach (var prop in expectedProps)
        {
            Assert.Contains(result.Errors, e => e.PropertyName == prop);
        }
    }
}