using HomeTrack.Application.Residents.Commands.UpdateResident;

namespace HomeTrack.IntegrationTests.Residents.Validators;

public class UpdateResidentCommandValidatorTests
{
    #region Data
    public static TheoryData<string, string, string> ValidData =>
        new()
        {
                {"fae3b80a-4d34-4e2a-9c5e-b0b09be2f678", "FirstName", "FirstSurname" },
                {"12df3156-a2c6-4b9c-8afe-e345b29b12ad", "SecondName", "SecondName"  },
                {"c377ea41-08b5-4979-9fc8-97e38e8d1658", "ThirdName", "ThirdName" }
        };

    public static TheoryData<string, string, string, string[]> InvalidData
        => new()
        {
            // Name and surname is empty
            { "47a6d58b-2f3e-4d9a-8c1f-0b1d2e3f4a5b",  "", "", new[] { "Name", "Surname" } },
            // Name is empty
            { "bf3e1a9c-4d7b-6e2f-9a8c-1b0d3f5e2a4c", "", "Surname", new[] { "Name" } },
            // Surname is empty
            { "c9d8e7f6-a5b4-3c2d-1e0f-9a8b7c6d5e4f", "Name", "", new[] { "Surname" } },
            // Name > 250 symbols
            { "e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b", new string('A', 251), "Surname", new[] { "Name" } },
            // Surname > 250 symbols
            { "a2b3c4d5-e6f7-8a9b-0c1d-2e3f4a5b6c7d", "Name", new string('B', 251), new[] { "Surname" } },
            // Both fields > 250 symbols
            { "d3e4f5a6-b7c8-9d0e-1f2a-3b4c5d6e7f8a", new string('A', 251), new string('B', 251),   new[] { "Surname" } },
            // Name contains invalid symbols
            { "f4a5b6c7-d8e9-0f1a-2b3c-4d5e6f7a8b9c", "Name123", "Surname", new[] { "Name" } },
            // Surname contains invalid symbols
            { "b5c6d7e8-f9a0-1b2c-3d4e-5f6a7b8c9d0e", "Name",   "Sur@name", new[] { "Surname" } },
            // Name and surname contains invalid symbols
            { "6e7f8a9b-0c1d-2e3f-4a5b-6c7d8e9f0a1b", "Na#me",   "Surn@me123", new[] { "Name",    "Surname" } },
            // Id is empty
            { "00000000-0000-0000-0000-000000000000", "Name",   "Surname", new[] { "Id" } },
        };
    #endregion

    [Theory]
    [MemberData(nameof(ValidData))]
    public void UpdateResidentCommandValidator_ValidData(
        string stringGuid,
        string name,
        string surname)
    {
        //Arrange
        var validator = new UpdateResidentCommandValidator();
        var command = new UpdateResidentCommand()
        {
            Id = Guid.Parse(stringGuid),
            Name = name,
            Surname = surname
        };

        //Act
        var result = validator.Validate(command);

        //Assert
        Assert.True(result.IsValid);
    }

    [Theory]
    [MemberData(nameof(InvalidData))]
    public void UpdateResidentCommandValidator_InvalidData(
        string stringGuid,
        string name,
        string surname,
        string[] expectedProps
    )
    {
        //Arrange
        var validator = new UpdateResidentCommandValidator();
        var command = new UpdateResidentCommand()
        {
            Id = Guid.Parse(stringGuid),
            Name = name,
            Surname = surname
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