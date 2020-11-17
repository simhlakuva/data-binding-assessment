using System.Linq;
using System.Runtime.CompilerServices;

public class EmbeddedImageConverter : IValueConverter
{
    /// Optional type located in the assembly you want to get the resource
    /// from - if not supplied, the API assumes the resource is located in
    /// this assembly.
    public Type ResolvingAssemblyType { get; set; }

    public object Convert(object value, Type targetType,
                          object parameter, CultureInfo culture)
    {
        var imageUrl = (value ?? "").ToString();
        if (string.IsNullOrEmpty(imageUrl))
            return null;

        return ImageSource.FromResource(imageUrl,
            ResolvingAssemblyType?.GetTypeInfo().Assembly);
    }

    public object ConvertBack(object value, Type targetType,
                              object parameter, CultureInfo culture)
    {
        throw new NotSupportedException(
          $"{nameof(EmbeddedImageConverter)} cannot be used on two-way bindings.");
    }
}