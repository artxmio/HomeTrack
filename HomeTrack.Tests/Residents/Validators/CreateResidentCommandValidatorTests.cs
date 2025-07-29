using HomeTrack.Application.Residents.Commands.CreateResident;
using HomeTrack.IntegrationTests.Common;

namespace HomeTrack.IntegrationTests.Residents.Validators;

public class CreateResidentCommandValidatorTests
{
    #region Data
    public static TheoryData<string, string> ValidData =>
        new()
        {
            {"FirstName", "FirstSurname" },
            {"SecondName", "SecondName"  },
            {"ThirdName", "ThirdName"    }
        };

    public static TheoryData<string, string, string[]> InvalidData
        => new()
        {
            // Both fields is empty
            { "",        "", new[] { "Name",    "Surname" }                     },
            // Name is empty
            { "",        "Surname", new[] { "Name" }                            },
            // Surname is empty
            { "Name",    "", new[] { "Surname" }                                },
            // Name > 250 symbols
            { new string('A', 251), "Surname", new[] { "Name" }                 },
            // Surname > 250 symbols
            { "Name",    new string('B', 251), new[] { "Surname" }              },
            // Both fields > 250 symbols
            { new string('A', 251), new string('B', 251),   new[] { "Surname" } },
            // Name contains invalid symbols
            { "Name123", "Surname", new[] { "Name" }                            },
            // Surname contains invalid symbols
            { "Name",   "Sur@name", new[] { "Surname" }                         },
            // Both fields contains invalid symbols
            { "Na#me",   "Surn@me123", new[] { "Name",    "Surname" }           },
        };
    #endregion

    [Theory]
    [InlineData("FirstName", "FirstSurname")]
    [InlineData("SecondName", "SecondSurname")]
    [InlineData("ThirdName", "ThirdSurname")]
    public void CreateResidentCommandValidator_ValidData(string name, string surname)
    {
        //Arrange
        var validator = new CreateResidentCommandValidator();
        var command = new CreateResidentCommand()
        {
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
    public void CreateResidentCommandValidator_InvalidData(
        string name, 
        string surname, 
        string[] expectedProps
    )
    {
        //Arrange
        var validator = new CreateResidentCommandValidator();
        var command = new CreateResidentCommand()
        {
            Name = name,
            Surname = surname,
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