using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Luma.Core.Domain.Toolkits.ValueObjects;

namespace Luma.Infra.Data.Sql.Commands.ValueConversions
{
    public class TitleConversion : ValueConverter<Title, string>
    {
        public TitleConversion() : base(c => c.Value, c => Title.FromString(c))
        {

        }
    }
}

