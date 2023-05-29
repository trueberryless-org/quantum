using System.Linq.Expressions;

namespace Quantum.WebAPI.Services;

public class FilterModel<TEntity> where TEntity : class
{
    public string PropertyName { get; set; }
    public string Operator { get; set; }
    public object Value { get; set; }

    public Expression<Func<TEntity, bool>> GetFilterExpression()
    {
        // Create the filter expression based on the model's properties
        // Here's an example implementation, assuming TEntity is the entity type
        var parameter = Expression.Parameter(typeof(TEntity), "e");
        var property = Expression.Property(parameter, PropertyName);
        var value = Expression.Constant(Value);
        var condition = Expression.Call(property, Operator, null, value);
        var lambda = Expression.Lambda<Func<TEntity, bool>>(condition, parameter);
        return lambda;
    }
}