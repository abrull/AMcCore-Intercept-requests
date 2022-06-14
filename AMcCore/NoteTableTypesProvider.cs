using Chorus.Conductor.Database;
using Chorus.Conductor.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace AmcInterception
{
    public class NoteTableTypesProvider : ITableTypesProvider
    {
        private readonly ITableTypesProvider _inner;

        public NoteTableTypesProvider(ITableTypesProvider inner)
        {
            _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        }

        public (Type[] syncTablesTypes, Type[] localTablesTypes) GetTypes()
        {
            var (syncTablesTypes, localTablesTypes) = _inner.GetTypes();
            var allLocalTablesTypes = localTablesTypes
                .Concat(typeof(ILocalEntity).GetAssignableTypes(GetType().Assembly))
                .Distinct()
                .ToArray();
            return (syncTablesTypes, allLocalTablesTypes);
        }

        public void Initialize(Assembly assembly)
        {
            _inner.Initialize(assembly);
        }
    }
}
