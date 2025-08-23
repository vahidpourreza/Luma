using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Luma.Core.Domain.Toolkits.ValueObjects;

namespace Luma.Infra.Data.Sql.Commands.ValueConversions
{
    public class DescriptionConversion : ValueConverter<Description, string>
    {
        public DescriptionConversion() : base(c => c.Value, c => Description.FromString(c))
        {

        }
    }
}

