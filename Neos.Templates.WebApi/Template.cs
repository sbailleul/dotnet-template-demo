namespace Neos.Templates.WebApi;

public class Template : IEquatable<Template>
{
    public Guid Id { get; set; }
    public string Property { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Property: {Property}";
    }

    public bool Equals(Template? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Template)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Template? left, Template? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Template? left, Template? right)
    {
        return !Equals(left, right);
    }

}