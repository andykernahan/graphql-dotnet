using System;
using GraphQL.Types;
using Xunit;

namespace GraphQL.Tests.Bugs
{
    public sealed class ValueTypeTests : QueryTestBase<ValueTypeSchema>
    {
        [Fact]
        public void can_resolve_property_on_struct()
        {
            var query = "query { seconds }";
            var expected = "{ seconds: 42 }";
            AssertQuerySuccess(query, expected, root: TimeSpan.FromSeconds(42));
        }
    }

    public sealed class ValueTypeSchema : Schema
    {
        public ValueTypeSchema()
        {
            var query = new ObjectGraphType<TimeSpan>();
            query.Field<IntGraphType>(
                name: "seconds"
            );
            Query = query;
        }
    }
}
