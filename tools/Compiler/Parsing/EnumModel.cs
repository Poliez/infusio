using System.Diagnostics;
using DotLiquid;
using LanguageExt;
using LanguageExt.TypeClasses;

namespace Infusio.Compiler.Parsing
{
    [DebuggerDisplay("Enum {Name}")]
    public class EnumModel : Record<EnumModel>, ILiquidizable
    {
        public EnumModel(string name = default, Lst<string> values = default, string description = default, string parenttype = default)
        {
            Name = name;
            ParentType = parenttype;
            Values = values;
            Description = description;
        }

        public string Name { get; }
        public string ParentType { get; }
        public Lst<string> Values { get; }
        public string Description { get; }
        public bool HasDescription => Prelude.notnull(Description);
        
        public object ToLiquid() => new {Name, ParentType, Values, Description, HasDescription};

        public struct NameEq : Eq<EnumModel>
        {
            public bool Equals(EnumModel x, EnumModel y) => x.Name.Equals(y.Name) && x.ParentType.Equals(y.ParentType);
            public int GetHashCode(EnumModel x) => x.Name.GetHashCode();
        }
    }
}