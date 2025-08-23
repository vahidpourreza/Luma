using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Luma.Core.Domain.ValueObjects;

namespace Luma.Infra.Data.Sql.Commands.ValueConversions
{
    public class BusinessIdConversion : ValueConverter<BusinessId, Guid>
    {
        public BusinessIdConversion() : base(c => c.Value, c => BusinessId.FromGuid(c))
        {

        }
    }
}

