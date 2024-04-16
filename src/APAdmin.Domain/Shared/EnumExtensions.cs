using System.ComponentModel;

namespace APAdmin.Domain;

public static class EnumExtensions
{
    public static string GetDescription(this Enum valorEnum)
    {
        var field = valorEnum.GetType().GetField(valorEnum.ToString());

        var atribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

        return atribute == null ? valorEnum.ToString() : atribute.Description;
    }
}
