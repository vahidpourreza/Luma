using Luma.Core.Domain.Toolkits.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Luma.Infra.Data.Sql.Commands.ValueConversions
{
    public class NameConversion : ValueConverter<Name, string>
    {
        public NameConversion() : base(c => c.Value, c => Name.FromString(c))
        {

        }
    }
}

