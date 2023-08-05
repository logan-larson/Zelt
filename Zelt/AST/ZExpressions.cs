using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    public abstract class ZExpression
    {
        public abstract ZType Type { get; }
        public abstract void CodeGen(StreamWriter streamWriter);
    }

    public class ZLiteralExpression : ZExpression
    {
        public override ZType Type { get; }
        
        public ZValue Value;

        public ZLiteralExpression(ZValue value)
        {
            Value = value;
            Type = value.Type;
        }

        public override void CodeGen(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }
    }

    public class ZIdentifierExpression : ZExpression
    {
        public override ZType Type { get; }

        public string Name;

        public ZIdentifierExpression(string name, ZType type)
        {
            Name = name;
            Type = type; // type is resolved and passed in by the parser based on the name
        }

        public override void CodeGen(StreamWriter streamWriter)
        {
            throw new NotImplementedException();
        }
    }
}
