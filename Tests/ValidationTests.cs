using System.ComponentModel.DataAnnotations;
using API.DTO;

namespace Tests
{
    public class ValidationTests
    {
        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);

            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("TesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTeste", false)]
        [InlineData("Teste", true)]
        public void TestUsuarioDTOValidation(string? nome, bool isValid)
        {
            var usuario = new UsuarioDTO { Nome = nome };

            Assert.Equal(isValid, ValidateModel(usuario));
        }
    }
}
