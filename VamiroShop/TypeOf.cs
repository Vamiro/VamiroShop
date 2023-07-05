namespace VamiroShop;

public static class TypeOf<T>
{
    public static readonly Type Raw = typeof(T);

    public static readonly string Name = Raw.Name;
    public static readonly string FullName = Raw.FullName;
    public static readonly bool IsValueType = Raw.IsValueType;

    public static bool IsAssignableFrom(Type other)
    {
        return Raw.IsAssignableFrom(other);
    }

    public static bool IsAssignableFrom<TOther>()
    {
        return Raw.IsAssignableFrom(TypeOf<TOther>.Raw);
    }

    private static readonly List<Type> _inheritors =
        EnumerateAll(x => x.IsClass && !x.IsAbstract && IsAssignableFrom(x)).ToList();

    public static IEnumerable<Type> Inheritors => _inheritors;

    private static IEnumerable<Type> EnumerateAll(Func<Type, bool> filter)
    {
        if (filter == null) throw new ArgumentNullException(nameof(filter));
        return AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic)
            .SelectMany(x => x.GetTypes().Where(filter));
    }
}