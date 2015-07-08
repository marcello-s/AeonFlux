#region license and copyright
/*
The MIT License, Copyright (c) 2011-2015 Marcel Schneider
for details see License.txt
 */
#endregion

namespace AeonFlux.Ast
{
    using System.Text;

    internal class IdentifierExpression : IExpression
    {
        public string Name { get; private set; }

        public IdentifierExpression(string name)
        {
            Name = name;
        }

        public R Accept<R, S>(IExpressionVisitor<R, S> visitor, S scope)
        {
            return visitor.Visit(this, scope);
        }

        public void AppendTo(StringBuilder sb)
        {
            sb.Append(Name);
        }
    }
}
