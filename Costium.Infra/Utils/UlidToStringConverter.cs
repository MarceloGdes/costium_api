using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Costium.Infra.Utils;
public class UlidToStringConverter : ValueConverter<Ulid, string> 
{
    public UlidToStringConverter() : base(
            ulid => ulid.ToString(),
            value => Ulid.Parse(value)){}
}
