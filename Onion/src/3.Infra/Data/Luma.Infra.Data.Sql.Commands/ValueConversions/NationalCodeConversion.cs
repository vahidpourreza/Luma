using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Luma.Core.Domain.Toolkits.ValueObjects;

namespace Luma.Infra.Data.Sql.Commands.ValueConversions
{
    public class NationalCodeConversion : ValueConverter<NationalCode, string>
    {
        public NationalCodeConversion() : base(c => c.Value, c => NationalCode.FromString(c))
        {

        }
    }
}

